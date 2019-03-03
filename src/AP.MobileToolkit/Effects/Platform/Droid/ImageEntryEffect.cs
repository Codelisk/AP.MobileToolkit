using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using AP.MobileToolkit;
using AP.MobileToolkit.Fonts;
using AP.MobileToolkit.Platform.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Application = Android.App.Application;

[assembly: ResolutionGroupName(Constants.ResolutionGroupName)]
[assembly: ExportEffect(typeof(AP.MobileToolkit.Effects.Platform.Droid.ImageEntryEffect), nameof(AP.MobileToolkit.Effects.Platform.Droid.ImageEntryEffect))]
namespace AP.MobileToolkit.Effects.Platform.Droid
{
    public class ImageEntryEffect : PlatformEffect<AP.MobileToolkit.Effects.ImageEntryEffect, Entry, EditText>
    {
        protected override async void OnAttached()
        {
            ImageSource source = null;
            if (!string.IsNullOrWhiteSpace(Effect.Icon) && IconFontRegistry.Instance.TryFindIconForKey(Effect.Icon, out var _))
            {
                source = new IconImageSource
                {
                    Color = Effect.LineColor,
                    Name = Effect.Icon,
                    Size = Effect.ImageWidth
                };
            }
            else if (Effect.ImageSource != null)
            {
                source = Effect.ImageSource;
            }
            else
            {
                return;
            }

            var handler = Xamarin.Forms.Internals.Registrar.Registered.GetHandlerForObject<IImageSourceHandler>(source);
            if (handler != null)
            {
                var bitmap = await handler.LoadImageAsync(source, Container.Context);
                SetImageOnEntry(new BitmapDrawable(Container.Context.Resources, bitmap));
            }
        }

        protected override void OnDetached()
        {

        }

        //private IImageSourceHandler GetImageHandler(ImageSource source)
        //{
        //    switch(source)
        //    {
        //        case UriImageSource uriSource:
        //            return new ImageLoaderSourceHandler();
        //        case FileImageSource fileSource:
        //            return new FileImageSourceHandler();
        //        case StreamImageSource streamSource:
        //            return new StreamImagesourceHandler();
        //        default:
        //            return null;
        //    }
        //}

        private void SetImageOnEntry(Drawable drawable)
        {
            var editText = this.Control;
            switch(Effect.Alignment)
            {
                case ImageAlignment.Left:
                    editText.SetCompoundDrawablesWithIntrinsicBounds(drawable, null, null, null);
                    break;
                case ImageAlignment.Right:
                    editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, drawable, null);
                    break;
            }

            editText.CompoundDrawablePadding = 25;
            Control.Background.SetColorFilter(Effect.LineColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
        }
    }
}