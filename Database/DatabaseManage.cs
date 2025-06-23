using System;
using System.Data.SQLite;
using System.IO;

namespace PadariaApp
{
    public class DatabaseManage
    {
        private static readonly string dbFile = "projetoPadariaApp.db";
        private static readonly string connectionString = $"Data Source={dbFile};Version=3;";

        private static DatabaseManage instance;


        private DatabaseManage()
        {
            if (!File.Exists(dbFile))
            {
                SQLiteConnection.CreateFile(dbFile);
                Console.WriteLine("Base de dados criada!");
                InitializeDatabase();
            }
        }

        public static DatabaseManage GetInstance()
        {
            if (instance == null)
                instance = new DatabaseManage();
            return instance;
        }

        public SQLiteConnection GetConnection()
        {
            // Crie uma nova conexão cada vez que for solicitada
            return new SQLiteConnection(connectionString);
        }


        private void InitializeDatabase()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        CreateTables(conn);
                        CreateFuncaoTableAndInsertData(conn);

                        // Inserir utilizadores de teste
                        InsertTestUsers(conn);

                        transaction.Commit();

                        Console.WriteLine("Tabelas criadas e funções inseridas com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Erro ao inicializar o banco de dados: " + ex.Message);
                    }
                }
            }
        }

        private void CreateTables(SQLiteConnection conn)
        {
                string schema = @"
        PRAGMA foreign_keys = ON;

        CREATE TABLE funcionario (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            nome TEXT NOT NULL,
            contacto TEXT NOT NULL,
            username TEXT NOT NULL,
            pass TEXT NOT NULL,
            id_funcao INTEGER NOT NULL
        );

        CREATE TABLE funcao (
            id_funcao INTEGER PRIMARY KEY AUTOINCREMENT,
            funcao TEXT NOT NULL
        );

        CREATE TABLE tipo_de_func (
            id_funcionario INTEGER NOT NULL,
            admin TEXT CHECK(admin IN ('S', 'N')) DEFAULT 'N',
            FOREIGN KEY (id_funcionario) REFERENCES funcionario(id) ON DELETE CASCADE
        );

        CREATE TABLE fornecedor (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            nome TEXT NOT NULL,
            contacto TEXT NOT NULL,
            email TEXT NOT NULL,
            tempo_de_entrega TEXT
        );

        CREATE TABLE materia (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            nome TEXT NOT NULL,
            id_fornecedor INTEGER NOT NULL,
            preco REAL NOT NULL,
            quantidade INTEGER,
            iva INTEGER CHECK(iva IN (6, 13, 23)) DEFAULT 23
        );

        CREATE TABLE encomenda (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            id_materia INTEGER NOT NULL,
            qtdd INTEGER NOT NULL,
            id_funcionario INTEGER NOT NULL,
            data_encomenda DATETIME DEFAULT CURRENT_TIMESTAMP,
            descricao TEXT,
            FOREIGN KEY (id_materia) REFERENCES materia(id) ON DELETE CASCADE,
            FOREIGN KEY (id_funcionario) REFERENCES funcionario(id) ON DELETE CASCADE
        );

        CREATE TABLE produtos (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            nome TEXT NOT NULL,
            quantidade INTEGER NOT NULL,
            preco REAL NOT NULL,
            iva INTEGER CHECK(iva IN (6, 13, 23)) DEFAULT 23,
            imagem TEXT
        );

        CREATE TABLE enc (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            nif_clientes TEXT NOT NULL,
            preco REAL NOT NULL,
            data_encomenda DATETIME DEFAULT CURRENT_TIMESTAMP,
            data_recolha DATETIME NOT NULL,
            pago TEXT CHECK(pago IN ('pago', 'não pago')) DEFAULT 'não pago',
            entregue TEXT CHECK(entregue IN ('S', 'N')) DEFAULT 'N'
        );

        CREATE TABLE enc_prod (
            id_enc INTEGER NOT NULL,
            id_prod INTEGER NOT NULL,
            qtdd INTEGER NOT NULL,
            FOREIGN KEY (id_enc) REFERENCES enc(id) ON DELETE CASCADE,
            FOREIGN KEY (id_prod) REFERENCES produtos(id) ON DELETE CASCADE
        );

        CREATE TABLE log (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            id_funcionario INTEGER,
            data DATETIME DEFAULT CURRENT_TIMESTAMP,
            descricao TEXT NOT NULL,
            FOREIGN KEY (id_funcionario) REFERENCES funcionario(id) ON DELETE SET NULL
        );

        CREATE TABLE fats (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            nif_cliente TEXT,
            data DATETIME DEFAULT CURRENT_TIMESTAMP,
            tipo TEXT CHECK(tipo IN ('final', 'nif')) DEFAULT 'final'
        );

        CREATE TABLE linha_de_fatura (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            id_produto INTEGER,
            preco_produto REAL,
            quantidade INTEGER,
            id_func INTEGER,
            FOREIGN KEY (id_produto) REFERENCES produtos(id) ON DELETE CASCADE,
            FOREIGN KEY (id_func) REFERENCES funcionario(id) ON DELETE SET NULL
        );

        CREATE TABLE fatura_linhas (
            id_fatura INTEGER,
            id_linha_de_fatura INTEGER,
            PRIMARY KEY (id_fatura, id_linha_de_fatura),
            FOREIGN KEY (id_fatura) REFERENCES fats(id) ON DELETE CASCADE,
            FOREIGN KEY (id_linha_de_fatura) REFERENCES linha_de_fatura(id) ON DELETE CASCADE
        );";

            using (var cmd = new SQLiteCommand(schema, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        private void CreateFuncaoTableAndInsertData(SQLiteConnection conn)
        {
            // Funções predefinidas a serem inseridas
            string[] funcoes = { "Caixa", "Stock", "Administrador", "Padaria" };

            foreach (var funcao in funcoes)
            {
                string insertFuncaoQuery = "INSERT OR IGNORE INTO funcao (funcao) VALUES (@funcao);";

                using (var cmd = new SQLiteCommand(insertFuncaoQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@funcao", funcao);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void InsertTestUsers(SQLiteConnection conn)
        {
            // Buscar os IDs das funções
            int idAdmin = GetFuncaoId(conn, "Administrador");
            int idCaixa = GetFuncaoId(conn, "Caixa");

            if (idAdmin == -1 || idCaixa == -1)
            {
                Console.WriteLine("Erro: Não foi possível encontrar os IDs das funções.");
                return;
            }

            // Hashear as passwords
            string hashedPasswordAdmin = BCrypt.Net.BCrypt.HashPassword("admin123");
            string hashedPasswordFunc = BCrypt.Net.BCrypt.HashPassword("func123");

            // Inserir utilizador admin
            string insertAdmin = @"INSERT INTO funcionario (nome, contacto, username, pass, id_funcao)
                                VALUES ('Admin Teste', '912345678', 'admin', @hashedPass, @idAdmin);
                                SELECT last_insert_rowid();";

            using (var cmd = new SQLiteCommand(insertAdmin, conn))
            {
                cmd.Parameters.AddWithValue("@hashedPass", hashedPasswordAdmin);
                cmd.Parameters.AddWithValue("@idAdmin", idAdmin);
                long adminId = (long)cmd.ExecuteScalar();

                string insertTipoFuncAdmin = "INSERT INTO tipo_de_func (id_funcionario, admin) VALUES (@id, 'S');";
                using (var cmdTipo = new SQLiteCommand(insertTipoFuncAdmin, conn))
                {
                    cmdTipo.Parameters.AddWithValue("@id", adminId);
                    cmdTipo.ExecuteNonQuery();
                }
            }

            // Inserir utilizador funcionário
            string insertUser = @"INSERT INTO funcionario (nome, contacto, username, pass, id_funcao)
                                VALUES ('Funcionario Teste', '923456789', 'func', @hashedPass, @idFuncao);
                                SELECT last_insert_rowid();";

            using (var cmd = new SQLiteCommand(insertUser, conn))
            {
                cmd.Parameters.AddWithValue("@hashedPass", hashedPasswordFunc);
                cmd.Parameters.AddWithValue("@idFuncao", idCaixa);
                long funcId = (long)cmd.ExecuteScalar();

                string insertTipoFunc = "INSERT INTO tipo_de_func (id_funcionario, admin) VALUES (@id, 'N');";
                using (var cmdTipo = new SQLiteCommand(insertTipoFunc, conn))
                {
                    cmdTipo.Parameters.AddWithValue("@id", funcId);
                    cmdTipo.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Utilizadores de teste inseridos com sucesso!");
        }


        private int GetFuncaoId(SQLiteConnection conn, string nomeFuncao)
        {
            string query = "SELECT id_funcao FROM funcao WHERE funcao = @nomeFuncao;";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nomeFuncao", nomeFuncao);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

    }
}

