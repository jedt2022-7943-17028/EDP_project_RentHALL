using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsSampleApp1.Properties
{
    public class CircularProgressBar : Control
    {
        private int _value = 0; // Current progress value
        private int _maximum = 100; // Maximum progress value
        private Color _progressColor = Color.Green; // Color of the progress arc
        private Color _backColor = Color.LightGray; // Background color of the arc
        private int _startAngle = -230; // Start angle for the 280-degree arc
        private int _sweepAngle = 280; // Total sweep angle (280 degrees)

        public CircularProgressBar()
        {
            this.DoubleBuffered = true; // Prevent flickering
            this.ResizeRedraw = true; // Redraw when resized
        }

        // Property for setting the progress value
        public int Value
        {
            get { return _value; }
            set
            {
                if (value < 0 || value > _maximum)
                    throw new ArgumentOutOfRangeException("Value must be between 0 and Maximum.");
                _value = value;
                Invalidate(); // Redraw the control
            }
        }

        // Property for setting the maximum value
        public int Maximum
        {
            get { return _maximum; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Maximum must be greater than 0.");
                _maximum = value;
                Invalidate(); // Redraw the control
            }
        }

        // Property for setting the progress color
        public Color ProgressColor
        {
            get { return _progressColor; }
            set
            {
                _progressColor = value;
                Invalidate(); // Redraw the control
            }
        }

        // Property for setting the background color
        public Color BackColorArc
        {
            get { return _backColor; }
            set
            {
                _backColor = value;
                Invalidate(); // Redraw the control
            }
        }

        // Override the OnPaint method to draw the progress bar
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Calculate the center and radius of the circle
            int diameter = Math.Min(this.Width, this.Height) - 10; // Adjust size
            int x = (this.Width - diameter) / 2;
            int y = (this.Height - diameter) / 2;
            Rectangle rect = new Rectangle(x, y, diameter, diameter);

            // Draw the background arc
            using (Pen backPen = new Pen(_backColor, 10))
            {
                g.DrawArc(backPen, rect, _startAngle, _sweepAngle);
            }

            // Calculate the sweep angle for the progress
            float sweep = (float)(_value / (double)_maximum) * _sweepAngle;

            // Draw the progress arc
            using (Pen progressPen = new Pen(_progressColor, 10))
            {
                g.DrawArc(progressPen, rect, _startAngle, sweep);
            }
        }
    }
}
