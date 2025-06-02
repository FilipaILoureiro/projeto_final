using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace projetoPadariaApp.Models
{
    public class Resizer
    {
        private struct ControlInfo
        {
            public Rectangle OriginalBounds;
            public AnchorStyles OriginalAnchor;
            public DockStyle OriginalDock;
        }

        private Dictionary<Control, ControlInfo> _controls = new Dictionary<Control, ControlInfo>();
        private Size _originalFormSize;
        private bool _isInitialized = false;

        public void InitializeResize(Form form)
        {
            if (_isInitialized) return;

            // Aguarda o form estar completamente carregado
            if (!form.IsHandleCreated || !form.Visible)
            {
                form.Shown += (s, e) => InitializeResize(form);
                return;
            }

            _originalFormSize = form.ClientSize;
            _controls.Clear();

            // Remove anchors e docks temporariamente para capturar posições originais
            CaptureControlsRecursive(form);

            _isInitialized = true;
        }

        private void CaptureControlsRecursive(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                // Salva as propriedades originais
                var info = new ControlInfo
                {
                    OriginalBounds = control.Bounds,
                    OriginalAnchor = control.Anchor,
                    OriginalDock = control.Dock
                };

                _controls[control] = info;

                // Remove anchor e dock para controle manual
                control.Anchor = AnchorStyles.None;
                control.Dock = DockStyle.None;

                // Recursivamente para controles filhos
                if (control.HasChildren)
                {
                    CaptureControlsRecursive(control);
                }
            }
        }

        public void PerformResize(Form form)
        {
            if (!_isInitialized || _originalFormSize.IsEmpty) return;

            var currentSize = form.ClientSize;

            // Evita divisão por zero
            if (_originalFormSize.Width == 0 || _originalFormSize.Height == 0) return;

            float scaleX = (float)currentSize.Width / _originalFormSize.Width;
            float scaleY = (float)currentSize.Height / _originalFormSize.Height;

            form.SuspendLayout();

            try
            {
                foreach (var pair in _controls)
                {
                    var control = pair.Key;
                    var info = pair.Value;

                    // Verifica se o controle ainda existe e tem parent válido
                    if (control.IsDisposed || control.Parent == null) continue;

                    var originalBounds = info.OriginalBounds;

                    var newBounds = new Rectangle(
                        (int)Math.Round(originalBounds.X * scaleX),
                        (int)Math.Round(originalBounds.Y * scaleY),
                        (int)Math.Round(originalBounds.Width * scaleX),
                        (int)Math.Round(originalBounds.Height * scaleY)
                    );

                    control.Bounds = newBounds;
                }
            }
            finally
            {
                form.ResumeLayout();
            }
        }

        public void Reset()
        {
            _controls.Clear();
            _originalFormSize = Size.Empty;
            _isInitialized = false;
        }
    }
}