// BlitzKarteView.xaml.cs
using Blitzkarten.Models;

namespace Blitzkarten.Controls;

public partial class BlitzKarteView : ContentView
{
    public static readonly BindableProperty BlitzKarteProperty =
        BindableProperty.Create(
            nameof(BlitzKarte),
            typeof(BlitzKarte),
            typeof(BlitzKarteView),
            default(BlitzKarte),
            propertyChanged: OnBlitzKarteChanged);

    public bool IsFrontSideVisible => _isFront;

    private static void OnBlitzKarteChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (BlitzKarteView)bindable;
        view.UpdateBindings(newValue as BlitzKarte);
    }

    public BlitzKarte BlitzKarte
    {
        get => (BlitzKarte)GetValue(BlitzKarteProperty);
        set => SetValue(BlitzKarteProperty, value);
    }

    private bool _isFront = true;

    public BlitzKarteView()
    {
        InitializeComponent();
    }

    private async void OnTapped(object sender, TappedEventArgs e)
    {
        await FlipCard();
    }

    public async Task FlipCard()
    {
        if (_isFront)
        {
            // Flip to back
            await frontView.RotateYTo(90, 150, Easing.Linear);
            frontView.IsVisible = false;
            backView.IsVisible = true;
            backView.RotationY = -90;
            await backView.RotateYTo(0, 150, Easing.Linear);
        }
        else
        {
            // Flip to front
            await backView.RotateYTo(90, 150, Easing.Linear);
            backView.IsVisible = false;
            frontView.IsVisible = true;
            frontView.RotationY = -90;
            await frontView.RotateYTo(0, 150, Easing.Linear);
        }

        _isFront = !_isFront;
    }

    private void UpdateBindings(BlitzKarte? blitzKarte)
    {
        // Set binding context for each view separately
        frontView.BindingContext = blitzKarte;
        backView.BindingContext = blitzKarte;
    }
}
