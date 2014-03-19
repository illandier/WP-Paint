using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Paint
{
    public partial class MainPage : PhoneApplicationPage
    {
        bool Draw = false;
        Point startPoint;
        Point currentPoint;
        Line drawLine;
        Rectangle drawRec;
        Ellipse drawEli;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            drawLine = new Line();
            drawRec = new Rectangle();
            drawEli = new Ellipse();
        }

        private void MainCanvas_Tap(object sender, GestureEventArgs e)
        {

        }

        private void MainCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Draw = false;
            if (Convert.ToBoolean(RadioLine.IsChecked))
            {
                MainCanvas.Children.Remove(drawLine);
                MainCanvas.Children.Add(drawLine);
            }
            if (Convert.ToBoolean(RadioEli.IsChecked))
            {
                MainCanvas.Children.Remove(drawEli);
                MainCanvas.Children.Add(drawEli);
            }
            if (Convert.ToBoolean(RadioRec.IsChecked))
            {

            }
        }

        private void MainCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Draw = true;
            if (Convert.ToBoolean(RadioLine.IsChecked))
            {
                drawLine = new Line();
            }
            if (Convert.ToBoolean(RadioEli.IsChecked))
            {
                drawEli = new Ellipse();
            }
            if (Convert.ToBoolean(RadioRec.IsChecked))
            {
                drawRec = new Rectangle();
            }
            startPoint = e.GetPosition(MainCanvas);
        }

        private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
        {

            if (Draw)
            {
                currentPoint = e.GetPosition(MainCanvas);
                if (Convert.ToBoolean(RadioLine.IsChecked))
                {
                    MainCanvas.Children.Remove(drawLine);
                    drawLine.X1 = startPoint.X;
                    drawLine.Y1 = startPoint.Y;
                    drawLine.X2 = currentPoint.X;
                    drawLine.Y2 = currentPoint.Y;

                    drawLine.Stroke = new SolidColorBrush(Color.FromArgb(255, Convert.ToByte(Convert.ToInt32(SliderRed.Value)), Convert.ToByte(Convert.ToInt32(SliderGreen.Value)), Convert.ToByte(Convert.ToInt32(SliderBlue.Value))));
                    drawLine.StrokeThickness = SliderThickness.Value;
                    drawLine.Opacity = 1;

                    MainCanvas.Children.Add(drawLine);
                }
                if (Convert.ToBoolean(RadioEli.IsChecked))
                {
                    MainCanvas.Children.Remove(drawEli);
                    drawEli.Height = Math.Abs(startPoint.Y - currentPoint.Y);
                    drawEli.Width = Math.Abs(startPoint.X - currentPoint.X);
                    drawEli.StrokeThickness = SliderThickness.Value;
                    drawEli.Stroke = new SolidColorBrush(Color.FromArgb(255, Convert.ToByte(Convert.ToInt32(SliderRed.Value)), Convert.ToByte(Convert.ToInt32(SliderGreen.Value)), Convert.ToByte(Convert.ToInt32(SliderBlue.Value))));
                    if (startPoint.Y >= currentPoint.Y)
                    {
                        Canvas.SetTop(drawEli, currentPoint.Y);
                    }
                    else
                    {
                        Canvas.SetTop(drawEli, startPoint.Y);
                    }
                    if (startPoint.X >= currentPoint.X)
                    {
                        Canvas.SetLeft(drawEli, currentPoint.X);
                    }
                    else
                    {
                        Canvas.SetLeft(drawEli, startPoint.X);
                    }


                    MainCanvas.Children.Add(drawEli);
                }
                if (Convert.ToBoolean(RadioRec.IsChecked))
                {
                    MainCanvas.Children.Remove(drawRec);
                    drawRec.Height = Math.Abs(startPoint.Y - currentPoint.Y);
                    drawRec.Width = Math.Abs(startPoint.X - currentPoint.X);
                    drawRec.StrokeThickness = SliderThickness.Value;
                    drawRec.Stroke = new SolidColorBrush(Color.FromArgb(255, Convert.ToByte(Convert.ToInt32(SliderRed.Value)), Convert.ToByte(Convert.ToInt32(SliderGreen.Value)), Convert.ToByte(Convert.ToInt32(SliderBlue.Value))));
                    if (startPoint.Y >= currentPoint.Y)
                    {
                        Canvas.SetTop(drawRec, currentPoint.Y);
                    }
                    else
                    {
                        Canvas.SetTop(drawRec, startPoint.Y);
                    }
                    if (startPoint.X >= currentPoint.X)
                    {
                        Canvas.SetLeft(drawRec, currentPoint.X);
                    }
                    else
                    {
                        Canvas.SetLeft(drawRec, startPoint.X);
                    }


                    MainCanvas.Children.Add(drawRec);
                }

            }
        }
    }
}