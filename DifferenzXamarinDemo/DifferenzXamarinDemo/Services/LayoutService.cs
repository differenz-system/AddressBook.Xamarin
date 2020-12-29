using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DifferenzXamarinDemo.Services
{
    /// <summary>
    /// LayoutService
    /// Handles Layout Service.
    /// </summary>
    public static class LayoutService
    {
        /// <summary>
        /// Initializes static members of the <see cref="LayoutService"/> class.
        /// </summary>
        static LayoutService()
        {

            FontSize08 = sizeConvertAsPerDevice(08);
            FontSize10 = sizeConvertAsPerDevice(10);
            FontSize11 = sizeConvertAsPerDevice(11);
            FontSize12 = sizeConvertAsPerDevice(12);
            FontSize13 = sizeConvertAsPerDevice(13);
            FontSize14 = sizeConvertAsPerDevice(14);
            FontSize15 = sizeConvertAsPerDevice(15);
            FontSize16 = sizeConvertAsPerDevice(16);
            FontSize17 = sizeConvertAsPerDevice(17);
            FontSize18 = sizeConvertAsPerDevice(18);
            FontSize20 = sizeConvertAsPerDevice(20);
            FontSize22 = sizeConvertAsPerDevice(22);
            FontSize24 = sizeConvertAsPerDevice(24);
            FontSize25 = sizeConvertAsPerDevice(25);
            FontSize26 = sizeConvertAsPerDevice(26);
            FontSize30 = sizeConvertAsPerDevice(30);
            FontSize40 = sizeConvertAsPerDevice(40);
            FontSize50 = sizeConvertAsPerDevice(50);
            FontSize60 = sizeConvertAsPerDevice(60);
            FontSize70 = sizeConvertAsPerDevice(70);
            FontSize80 = sizeConvertAsPerDevice(80);
            FontSize100 = sizeConvertAsPerDevice(100);
            FontSize130 = sizeConvertAsPerDevice(130);

            HeightWidth1 = sizeConvertAsPerDevice(1);
            HeightWidth3 = sizeConvertAsPerDevice(3);
            HeightWidth15 = sizeConvertAsPerDevice(15);
            HeightWidth20 = sizeConvertAsPerDevice(20);
            HeightWidth22 = sizeConvertAsPerDevice(22);
            HeightWidth25 = sizeConvertAsPerDevice(25);
            HeightWidth30 = sizeConvertAsPerDevice(30);
            HeightWidth40 = sizeConvertAsPerDevice(40);
            HeightWidth45 = sizeConvertAsPerDevice(45);
            HeightWidth50 = sizeConvertAsPerDevice(50);
            HeightWidth60 = sizeConvertAsPerDevice(60);
            HeightWidth70 = sizeConvertAsPerDevice(70);
            HeightWidth80 = sizeConvertAsPerDevice(80);
            HeightWidth90 = sizeConvertAsPerDevice(90);
            HeightWidth100 = sizeConvertAsPerDevice(100);
            HeightWidth120 = sizeConvertAsPerDevice(120);
            HeightWidth130 = sizeConvertAsPerDevice(130);
            HeightWidth150 = sizeConvertAsPerDevice(150);
            HeightWidth180 = sizeConvertAsPerDevice(180);
            HeightWidth300 = sizeConvertAsPerDevice(300);
            HeightWidth400 = sizeConvertAsPerDevice(400);

            Spacing03 = sizeConvertAsPerDevice(3);
            Spacing05 = sizeConvertAsPerDevice(5);
            Spacing10 = sizeConvertAsPerDevice(10);
            Spacing15 = sizeConvertAsPerDevice(15);
            Spacing20 = sizeConvertAsPerDevice(20);
            Spacing30 = sizeConvertAsPerDevice(30);
            Spacing60 = sizeConvertAsPerDevice(60);

            CornerRadius04 = (float)sizeConvertAsPerDevice(04);
            CornerRadius10 = (float)sizeConvertAsPerDevice(10);
            CornerRadius15 = (float)sizeConvertAsPerDevice(15);
            CornerRadius20 = (float)sizeConvertAsPerDevice(20);
            CornerRadius25 = (float)sizeConvertAsPerDevice(25);
            CornerRadius30 = (float)sizeConvertAsPerDevice(30);
            CornerRadius40 = (float)sizeConvertAsPerDevice(40);
            GBCallCornerRadius25 = (float)sizeConvertAsPerDevice(25);

            ButtonCornerRadius10 = (int)sizeConvertAsPerDevice(10);
            ButtonCornerRadius15 = (int)sizeConvertAsPerDevice(15);
            ButtonCornerRadius25 = (int)sizeConvertAsPerDevice(25);

            GridHeightWidth1 = sizeConvertAsPerDevice(1);
            GridHeightWidth3 = sizeConvertAsPerDevice(3);
            GridHeightWidth20 = sizeConvertAsPerDevice(20);
            GridHeightWidth30 = sizeConvertAsPerDevice(30);
            GridHeightWidth40 = sizeConvertAsPerDevice(40);
            GridHeightWidth50 = sizeConvertAsPerDevice(50);
            GridHeightWidth60 = sizeConvertAsPerDevice(60);
            GridHeightWidth80 = sizeConvertAsPerDevice(80);
            GridHeightWidth100 = sizeConvertAsPerDevice(100);
            GridHeightWidth120 = sizeConvertAsPerDevice(120);
            GBCallGridHeight50 = sizeConvertAsPerDevice(50);

            MarginPadding02 = MarginPaddingConvertAsPerDevice(02, 02, 02, 02);
            MarginPadding05 = MarginPaddingConvertAsPerDevice(05, 05, 05, 05);
            MarginPadding10 = MarginPaddingConvertAsPerDevice(10, 10, 10, 10);
            MarginPadding12 = MarginPaddingConvertAsPerDevice(12, 12, 12, 12);
            MarginPadding15 = MarginPaddingConvertAsPerDevice(15, 15, 15, 15);
            MarginPadding20 = MarginPaddingConvertAsPerDevice(20, 20, 20, 20);
            MarginPadding30 = MarginPaddingConvertAsPerDevice(30, 30, 30, 30);
            MarginPadding50 = MarginPaddingConvertAsPerDevice(30, 30, 30, 30);

            MarginPadding00_05_00_00 = MarginPaddingConvertAsPerDevice(00, 05, 00, 00);
            MarginPadding05_00_05_00 = MarginPaddingConvertAsPerDevice(05, 00, 05, 00);
            MarginPadding00_05_00_05 = MarginPaddingConvertAsPerDevice(00, 05, 00, 05);
            MarginPadding05_15_05_00 = MarginPaddingConvertAsPerDevice(05, 15, 05, 00);
            MarginPadding10_05_10_05 = MarginPaddingConvertAsPerDevice(10, 05, 10, 05);
            MarginPadding10_00_10_00 = MarginPaddingConvertAsPerDevice(10, 00, 10, 00);
            MarginPadding10_10_10_00 = MarginPaddingConvertAsPerDevice(10, 10, 10, 00);
            MarginPadding10_00_10_10 = MarginPaddingConvertAsPerDevice(10, 00, 10, 10);
            MarginPadding00_00_10_00 = MarginPaddingConvertAsPerDevice(00, 00, 10, 00);
            MarginPadding00_10_00_10 = MarginPaddingConvertAsPerDevice(00, 10, 00, 10);
            MarginPadding00_10_00_00 = MarginPaddingConvertAsPerDevice(00, 10, 00, 00);
            MarginPadding10_00_00_00 = MarginPaddingConvertAsPerDevice(10, 00, 00, 00);
            MarginPadding00_00_00_10 = MarginPaddingConvertAsPerDevice(00, 00, 00, 10);
            MarginPadding12_00_12_00 = MarginPaddingConvertAsPerDevice(12, 00, 12, 00);
            MarginPadding15_15_15_10 = MarginPaddingConvertAsPerDevice(15, 15, 15, 10);
            MarginPadding15_00_00_00 = MarginPaddingConvertAsPerDevice(15, 00, 00, 00);
            MarginPadding00_00_15_00 = MarginPaddingConvertAsPerDevice(00, 00, 15, 00);
            MarginPadding20_00_20_00 = MarginPaddingConvertAsPerDevice(20, 00, 20, 00);
            MarginPadding20_20_00_00 = MarginPaddingConvertAsPerDevice(20, 20, 00, 00);
            MarginPadding00_20_20_00 = MarginPaddingConvertAsPerDevice(00, 20, 20, 00);
            MarginPadding00_00_20_00 = MarginPaddingConvertAsPerDevice(00, 00, 20, 00);
            MarginPadding00_20_00_00 = MarginPaddingConvertAsPerDevice(00, 20, 00, 00);
            MarginPadding00_20_00_20 = MarginPaddingConvertAsPerDevice(00, 20, 00, 20);
            MarginPadding20_20_20_00 = MarginPaddingConvertAsPerDevice(20, 20, 20, 00);
            MarginPadding20_00_00_00 = MarginPaddingConvertAsPerDevice(20, 00, 00, 00);
            MarginPadding00_00_00_20 = MarginPaddingConvertAsPerDevice(00, 00, 00, 20);
            MarginPadding20_10_20_10 = MarginPaddingConvertAsPerDevice(20, 10, 20, 10);
            MarginPadding20_10_20_00 = MarginPaddingConvertAsPerDevice(20, 10, 20, 00);
            MarginPadding20_00_20_10 = MarginPaddingConvertAsPerDevice(20, 00, 20, 10);
            MarginPadding20_05_10_05 = MarginPaddingConvertAsPerDevice(20, 05, 10, 05);
            MarginPadding20_00_20_20 = MarginPaddingConvertAsPerDevice(20, 00, 20, 20);
            MarginPadding60_15_60_15 = MarginPaddingConvertAsPerDevice(60, 15, 60, 15);

            MarginPadding20_07_20_07 = MarginPaddingConvertAsPerDevice(20, 07, 20, 07);
            MarginPadding30_00_00_00 = MarginPaddingConvertAsPerDevice(30, 00, 00, 00);
            MarginPadding00_30_00_00 = MarginPaddingConvertAsPerDevice(00, 30, 00, 00);
            MarginPadding00_30_00_30 = MarginPaddingConvertAsPerDevice(00, 30, 00, 30);
            MarginPadding30_00_30_00 = MarginPaddingConvertAsPerDevice(30, 00, 30, 00);
            MarginPadding30_00_30_20 = MarginPaddingConvertAsPerDevice(30, 00, 30, 20);
            MarginPadding00_50_00_00 = MarginPaddingConvertAsPerDevice(00, 50, 00, 00);
            MarginPadding0_120_0_0 = MarginPaddingConvertAsPerDevice(0, 120, 0, 0);
            MarginPadding0_200_0_0 = MarginPaddingConvertAsPerDevice(0, 200, 0, 0);

            MarginPadding0_m20_0_0 = MarginPaddingConvertAsPerDevice(0, -20, 0, 0);
            MarginPaddingm20_0_0_0 = MarginPaddingConvertAsPerDevice(-20, 0, 0, 0);
            MarginPadding0_0_m20_0 = MarginPaddingConvertAsPerDevice(0, 0, -20, 0);

            MarginPadding20_m05_0_m05 = MarginPaddingConvertAsPerDevice(20, -5, 0, -5);
            MarginPadding20_m07_0_m07 = MarginPaddingConvertAsPerDevice(20, -7, 0, -7);
            MarginPadding0_0_0_m40 = MarginPaddingConvertAsPerDevice(0, 0, 0, -40);

            MarginPadding0_m10_m20_m10 = MarginPaddingConvertAsPerDevice(0, -10, -20, -10);
            MarginPadding00_00_00_m10 = MarginPaddingConvertAsPerDevice(0, 0, 0, -10);
            MarginPaddingm20_m10_0_m10 = MarginPaddingConvertAsPerDevice(-20, -10, 0, -10);

            MarginPadding15_0_0_0 = MarginPaddingConvertAsPerDevice(15, 0, 0, 0);
            MarginPadding15_0_0_m100 = MarginPaddingConvertAsPerDevice(15, 0, 0, -100);

        }

        /// <summary>
        /// Defines the SmallDeviceSize.
        /// </summary>
        static double SmallDeviceSize = 700;

        /// <summary>
        /// The CalculateSize.
        /// </summary>
        /// <param name="val">The val<see cref="double"/>.</param>
        /// <param name="d">The d<see cref="double"/>.</param>
        /// <returns>The <see cref="double"/>.</returns>
        static double CalculateSize(double val, double d)
        {
            if (d == 0)
            {
                return val;
            }
            if (Device.Idiom == TargetIdiom.Phone)
            {
                if (val > 0)
                {
                    var half = val / d;
                    val = val - half;
                }
                else if (val < 0)
                {
                    var half = Math.Abs(val) / d;
                    val = -(Math.Abs(val) - half);
                }
            }
            else
            {
                if (val > 0)
                {
                    var half = val / d;
                    val = val + half;
                }
                else if (val < 0)
                {
                    var half = Math.Abs(val) / d;
                    val = -(Math.Abs(val) + half);
                }
            }
            return val;
        }

        /// <summary>
        /// The sizeConvertAsPerDevice.
        /// </summary>
        /// <param name="size">The size<see cref="double"/>.</param>
        /// <returns>The <see cref="double"/>.</returns>
        public static double sizeConvertAsPerDevice(double size)
        {
            try
            {
                if (size <= 0) { return 0; }
                int d = 0;
                if (Device.Idiom == TargetIdiom.Phone)
                {

                    var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
                    var Height = mainDisplayInfo.Height / mainDisplayInfo.Density;

                    if (Device.RuntimePlatform == Device.iOS)
                    {

                        if (mainDisplayInfo.Height <= 1136)
                        {
                            d = 5;
                        }
                        else if (mainDisplayInfo.Height <= 1334)
                        {
                            d = 7;
                        }
                    }
                    else
                    {
                        if (Height <= SmallDeviceSize)
                        {
                            //For Small Size Devices
                            d = 4;
                        }
                    }
                }
                else
                {
                    d = 2;
                }
                size = CalculateSize(size, d);
            }
            catch (Exception exception)
            {
                TelemetryService.Instance.Record(exception);
            }
            return size;
        }

        /// <summary>
        /// The MarginPaddingConvertAsPerDevice.
        /// </summary>
        /// <param name="left">The left<see cref="double"/>.</param>
        /// <param name="top">The top<see cref="double"/>.</param>
        /// <param name="right">The right<see cref="double"/>.</param>
        /// <param name="bottom">The bottom<see cref="double"/>.</param>
        /// <returns>The <see cref="Thickness"/>.</returns>
        public static Thickness MarginPaddingConvertAsPerDevice(double left, double top, double right, double bottom)
        {
            try
            {
                int d = 0;

                if (Device.Idiom == TargetIdiom.Phone)
                {

                    var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
                    var Height = mainDisplayInfo.Height / mainDisplayInfo.Density;

                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        if (mainDisplayInfo.Height <= 1136)
                        {
                            d = 5;
                        }
                        else if (mainDisplayInfo.Height <= 1334)
                        {
                            d = 7;
                        }
                    }
                    else
                    {
                        if (Height <= SmallDeviceSize)
                        {
                            //For Small Size Devices
                            d = 4;
                        }
                    }
                }
                else
                {
                    d = 2;
                }

                left = CalculateSize(left, d);
                top = CalculateSize(top, d);
                right = CalculateSize(right, d);
                bottom = CalculateSize(bottom, d);
            }
            catch (Exception exception)
            {
                TelemetryService.Instance.Record(exception);
            }
            return new Thickness(left, top, right, bottom);
        }


        #region Font Size
        /// <summary>
        /// Gets or sets the FontSize08.
        /// </summary>
        public static Double FontSize08 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize10.
        /// </summary>
        public static Double FontSize10 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize11.
        /// </summary>
        public static Double FontSize11 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize12.
        /// </summary>
        public static Double FontSize12 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize13.
        /// </summary>
        public static Double FontSize13 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize14.
        /// </summary>
        public static Double FontSize14 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize15.
        /// </summary>
        public static Double FontSize15 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize16.
        /// </summary>
        public static Double FontSize16 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize17.
        /// </summary>
        public static Double FontSize17 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize18.
        /// </summary>
        public static Double FontSize18 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize20.
        /// </summary>
        public static Double FontSize20 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize22.
        /// </summary>
        public static Double FontSize22 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize24.
        /// </summary>
        public static Double FontSize24 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize25.
        /// </summary>
        public static Double FontSize25 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize26.
        /// </summary>
        public static Double FontSize26 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize30.
        /// </summary>
        public static Double FontSize30 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize40.
        /// </summary>
        public static Double FontSize40 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize50.
        /// </summary>
        public static Double FontSize50 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize60.
        /// </summary>
        public static Double FontSize60 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize70.
        /// </summary>
        public static Double FontSize70 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize80.
        /// </summary>
        public static Double FontSize80 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize100.
        /// </summary>
        public static Double FontSize100 { get; set; }

        /// <summary>
        /// Gets or sets the FontSize130.
        /// </summary>
        public static Double FontSize130 { get; set; }

        #endregion

        #region View Height Width
        /// <summary>
        /// Gets or sets the HeightWidth1.
        /// </summary>
        public static Double HeightWidth1 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth3.
        /// </summary>
        public static Double HeightWidth3 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth15.
        /// </summary>
        public static Double HeightWidth15 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth20.
        /// </summary>
        public static Double HeightWidth20 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth22.
        /// </summary>
        public static Double HeightWidth22 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth25.
        /// </summary>
        public static Double HeightWidth25 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth30.
        /// </summary>
        public static Double HeightWidth30 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth40.
        /// </summary>
        public static Double HeightWidth40 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth45.
        /// </summary>
        public static Double HeightWidth45 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth50.
        /// </summary>
        public static Double HeightWidth50 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth60.
        /// </summary>
        public static Double HeightWidth60 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth70.
        /// </summary>
        public static Double HeightWidth70 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth80.
        /// </summary>
        public static Double HeightWidth80 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth90.
        /// </summary>
        public static Double HeightWidth90 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth100.
        /// </summary>
        public static Double HeightWidth100 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth120.
        /// </summary>
        public static Double HeightWidth120 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth130.
        /// </summary>
        public static Double HeightWidth130 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth150.
        /// </summary>
        public static Double HeightWidth150 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth180.
        /// </summary>
        public static Double HeightWidth180 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth300.
        /// </summary>
        public static Double HeightWidth300 { get; set; }

        /// <summary>
        /// Gets or sets the HeightWidth400.
        /// </summary>
        public static Double HeightWidth400 { get; set; }

        #endregion

        #region View Spacing
        /// <summary>
        /// Gets or sets the Spacing03.
        /// </summary>
        public static Double Spacing03 { get; set; }

        /// <summary>
        /// Gets or sets the Spacing05.
        /// </summary>
        public static Double Spacing05 { get; set; }

        /// <summary>
        /// Gets or sets the Spacing10.
        /// </summary>
        public static Double Spacing10 { get; set; }

        /// <summary>
        /// Gets or sets the Spacing15.
        /// </summary>
        public static Double Spacing15 { get; set; }

        /// <summary>
        /// Gets or sets the Spacing20.
        /// </summary>
        public static Double Spacing20 { get; set; }

        /// <summary>
        /// Gets or sets the Spacing30.
        /// </summary>
        public static Double Spacing30 { get; set; }

        /// <summary>
        /// Gets or sets the Spacing60.
        /// </summary>
        public static Double Spacing60 { get; set; }

        #endregion

        #region Corner Radius
        /// <summary>
        /// Gets or sets the CornerRadius04.
        /// </summary>
        public static Single CornerRadius04 { get; set; }

        /// <summary>
        /// Gets or sets the CornerRadius10.
        /// </summary>
        public static Single CornerRadius10 { get; set; }

        /// <summary>
        /// Gets or sets the CornerRadius15.
        /// </summary>
        public static Single CornerRadius15 { get; set; }

        /// <summary>
        /// Gets or sets the CornerRadius20.
        /// </summary>
        public static Single CornerRadius20 { get; set; }

        /// <summary>
        /// Gets or sets the CornerRadius25.
        /// </summary>
        public static Single CornerRadius25 { get; set; }

        /// <summary>
        /// Gets or sets the CornerRadius30.
        /// </summary>
        public static Single CornerRadius30 { get; set; }

        /// <summary>
        /// Gets or sets the CornerRadius40.
        /// </summary>
        public static Single CornerRadius40 { get; set; }

        /// <summary>
        /// Gets or sets the GBCallCornerRadius25.
        /// </summary>
        public static Single GBCallCornerRadius25 { get; set; }

        /// <summary>
        /// Gets or sets the ButtonCornerRadius10.
        /// </summary>
        public static int ButtonCornerRadius10 { get; set; }

        /// <summary>
        /// Gets or sets the ButtonCornerRadius15.
        /// </summary>
        public static int ButtonCornerRadius15 { get; set; }

        /// <summary>
        /// Gets or sets the ButtonCornerRadius25.
        /// </summary>
        public static int ButtonCornerRadius25 { get; set; }

        #endregion

        #region Grid Height Width
        /// <summary>
        /// Gets or sets the GridHeightWidth1.
        /// </summary>
        public static GridLength GridHeightWidth1 { get; set; }

        /// <summary>
        /// Gets or sets the GridHeightWidth3.
        /// </summary>
        public static GridLength GridHeightWidth3 { get; set; }

        /// <summary>
        /// Gets or sets the GridHeightWidth20.
        /// </summary>
        public static GridLength GridHeightWidth20 { get; set; }

        /// <summary>
        /// Gets or sets the GridHeightWidth30.
        /// </summary>
        public static GridLength GridHeightWidth30 { get; set; }

        /// <summary>
        /// Gets or sets the GridHeightWidth40.
        /// </summary>
        public static GridLength GridHeightWidth40 { get; set; }

        /// <summary>
        /// Gets or sets the GridHeightWidth50.
        /// </summary>
        public static GridLength GridHeightWidth50 { get; set; }

        /// <summary>
        /// Gets or sets the GridHeightWidth60.
        /// </summary>
        public static GridLength GridHeightWidth60 { get; set; }

        /// <summary>
        /// Gets or sets the GridHeightWidth80.
        /// </summary>
        public static GridLength GridHeightWidth80 { get; set; }

        /// <summary>
        /// Gets or sets the GridHeightWidth100.
        /// </summary>
        public static GridLength GridHeightWidth100 { get; set; }

        /// <summary>
        /// Gets or sets the GridHeightWidth120.
        /// </summary>
        public static GridLength GridHeightWidth120 { get; set; }

        /// <summary>
        /// Gets or sets the GBCallGridHeight50.
        /// </summary>
        public static GridLength GBCallGridHeight50 { get; set; }

        #endregion

        #region View Margin Padding

        /// <summary>
        /// Gets or sets the MarginPadding02.
        /// </summary>
        public static Thickness MarginPadding02 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding05.
        /// </summary>
        public static Thickness MarginPadding05 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding10.
        /// </summary>
        public static Thickness MarginPadding10 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding12.
        /// </summary>
        public static Thickness MarginPadding12 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding15.
        /// </summary>
        public static Thickness MarginPadding15 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding20.
        /// </summary>
        public static Thickness MarginPadding20 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding30.
        /// </summary>
        public static Thickness MarginPadding30 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding50.
        /// </summary>
        public static Thickness MarginPadding50 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding00_05_00_00.
        /// </summary>
        public static Thickness MarginPadding00_05_00_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding05_00_05_00.
        /// </summary>
        public static Thickness MarginPadding05_00_05_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding00_05_00_05.
        /// </summary>
        public static Thickness MarginPadding00_05_00_05 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding05_15_05_00.
        /// </summary>
        public static Thickness MarginPadding05_15_05_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding10_05_10_05.
        /// </summary>
        public static Thickness MarginPadding10_05_10_05 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding10_00_10_00.
        /// </summary>
        public static Thickness MarginPadding10_00_10_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding10_10_10_00.
        /// </summary>
        public static Thickness MarginPadding10_10_10_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding10_00_10_10.
        /// </summary>
        public static Thickness MarginPadding10_00_10_10 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding00_00_10_00.
        /// </summary>
        public static Thickness MarginPadding00_00_10_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding00_10_00_10.
        /// </summary>
        public static Thickness MarginPadding00_10_00_10 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding00_10_00_00.
        /// </summary>
        public static Thickness MarginPadding00_10_00_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding10_00_00_00.
        /// </summary>
        public static Thickness MarginPadding10_00_00_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding00_00_00_10.
        /// </summary>
        public static Thickness MarginPadding00_00_00_10 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding12_00_12_00.
        /// </summary>
        public static Thickness MarginPadding12_00_12_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding15_15_15_10.
        /// </summary>
        public static Thickness MarginPadding15_15_15_10 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding15_00_00_00.
        /// </summary>
        public static Thickness MarginPadding15_00_00_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding00_00_15_00.
        /// </summary>
        public static Thickness MarginPadding00_00_15_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding20_00_20_00.
        /// </summary>
        public static Thickness MarginPadding20_00_20_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding20_20_00_00.
        /// </summary>
        public static Thickness MarginPadding20_20_00_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding00_20_20_00.
        /// </summary>
        public static Thickness MarginPadding00_20_20_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding00_00_20_00.
        /// </summary>
        public static Thickness MarginPadding00_00_20_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding00_20_00_00.
        /// </summary>
        public static Thickness MarginPadding00_20_00_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding00_20_00_20.
        /// </summary>
        public static Thickness MarginPadding00_20_00_20 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding20_20_20_00.
        /// </summary>
        public static Thickness MarginPadding20_20_20_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding20_00_00_00.
        /// </summary>
        public static Thickness MarginPadding20_00_00_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding00_00_00_20.
        /// </summary>
        public static Thickness MarginPadding00_00_00_20 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding20_10_20_10.
        /// </summary>
        public static Thickness MarginPadding20_10_20_10 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding20_10_20_00.
        /// </summary>
        public static Thickness MarginPadding20_10_20_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding20_00_20_10.
        /// </summary>
        public static Thickness MarginPadding20_00_20_10 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding20_05_10_05.
        /// </summary>
        public static Thickness MarginPadding20_05_10_05 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding20_00_20_20.
        /// </summary>
        public static Thickness MarginPadding20_00_20_20 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding60_15_60_15.
        /// </summary>
        public static Thickness MarginPadding60_15_60_15 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding20_07_20_07.
        /// </summary>
        public static Thickness MarginPadding20_07_20_07 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding30_00_00_00.
        /// </summary>
        public static Thickness MarginPadding30_00_00_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding00_30_00_00.
        /// </summary>
        public static Thickness MarginPadding00_30_00_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding00_30_00_30.
        /// </summary>
        public static Thickness MarginPadding00_30_00_30 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding30_00_30_00.
        /// </summary>
        public static Thickness MarginPadding30_00_30_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding30_00_30_20.
        /// </summary>
        public static Thickness MarginPadding30_00_30_20 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding00_50_00_00.
        /// </summary>
        public static Thickness MarginPadding00_50_00_00 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding0_120_0_0.
        /// </summary>
        public static Thickness MarginPadding0_120_0_0 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding0_200_0_0.
        /// </summary>
        public static Thickness MarginPadding0_200_0_0 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding0_m20_0_0.
        /// </summary>
        public static Thickness MarginPadding0_m20_0_0 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPaddingm20_0_0_0.
        /// </summary>
        public static Thickness MarginPaddingm20_0_0_0 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding0_0_m20_0.
        /// </summary>
        public static Thickness MarginPadding0_0_m20_0 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding20_m05_0_m05.
        /// </summary>
        public static Thickness MarginPadding20_m05_0_m05 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding20_m07_0_m07.
        /// </summary>
        public static Thickness MarginPadding20_m07_0_m07 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding0_0_0_m40.
        /// </summary>
        public static Thickness MarginPadding0_0_0_m40 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding0_m10_m20_m10.
        /// </summary>
        public static Thickness MarginPadding0_m10_m20_m10 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding00_00_00_m10.
        /// </summary>
        public static Thickness MarginPadding00_00_00_m10 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPaddingm20_m10_0_m10.
        /// </summary>
        public static Thickness MarginPaddingm20_m10_0_m10 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding15_0_0_0.
        /// </summary>
        public static Thickness MarginPadding15_0_0_0 { get; set; }

        /// <summary>
        /// Gets or sets the MarginPadding15_0_0_m100.
        /// </summary>
        public static Thickness MarginPadding15_0_0_m100 { get; set; }

        #endregion


    }
}