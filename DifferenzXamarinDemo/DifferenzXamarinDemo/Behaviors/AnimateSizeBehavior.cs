using System;
using Xamarin.Forms;

namespace DifferenzXamarinDemo.Behaviors
{
    public class AnimateSizeBehavior : Behavior<View> 
	{
		public static readonly BindableProperty EasingFunctionProperty = BindableProperty.Create<AnimateSizeBehavior, string>(
			p => p.EasingFunctionName,
			"SinIn",
			propertyChanged: OnEasingFunctionChanged);

		public static readonly BindableProperty ScaleProperty = BindableProperty.Create<AnimateSizeBehavior, double>(
			p => p.Scale,
			1.15);

		private Easing _easingFunction;

		public string EasingFunctionName
		{
			get { return (string)GetValue(EasingFunctionProperty); }
			set { SetValue(EasingFunctionProperty, value); }
		}

		public double Scale
		{
			get { return (double)GetValue(ScaleProperty); }
			set { SetValue(ScaleProperty, value); }
		}

        

        protected override void OnAttachedTo(View bindable)
        {
			bindable.Focused += OnItemFocused;
			base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(View bindable)
        {
			bindable.Focused -= OnItemFocused;
			base.OnDetachingFrom(bindable);
        }

		private static Easing GetEasing(string easingName)
		{
			switch (easingName)
			{
				case "BounceIn": return Easing.BounceIn;
				case "BounceOut": return Easing.BounceOut;
				case "CubicInOut": return Easing.CubicInOut;
				case "CubicOut": return Easing.CubicOut;
				case "Linear": return Easing.Linear;
				case "SinIn": return Easing.SinIn;
				case "SinInOut": return Easing.SinInOut;
				case "SinOut": return Easing.SinOut;
				case "SpringIn": return Easing.SpringIn;
				case "SpringOut": return Easing.SpringOut;
				default: throw new ArgumentException(easingName + " is not valid");
			}
		}

		private static void OnEasingFunctionChanged(BindableObject bindable, string oldvalue, string newvalue)
		{
			(bindable as AnimateSizeBehavior).EasingFunctionName = newvalue;
			(bindable as AnimateSizeBehavior)._easingFunction = GetEasing(newvalue);
		}

		private async void OnItemFocused(object sender, FocusEventArgs e)
		{
			var view = sender as View;
			await view.ScaleTo(Scale, 250, _easingFunction);
			await view.ScaleTo(1.00, 250, _easingFunction);
		}
	}
}

