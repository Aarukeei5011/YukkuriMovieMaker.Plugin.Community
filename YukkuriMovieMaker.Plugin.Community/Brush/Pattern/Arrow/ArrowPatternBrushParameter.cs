﻿using System.ComponentModel.DataAnnotations;
using System.Windows.Media;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Plugin.Brush;

namespace YukkuriMovieMaker.Plugin.Community.Brush.Pattern.Arrow
{
    internal class ArrowPatternBrushParameter : DrawingBrushParameterBase
    {
        [Display(Name = nameof(Texts.Color), ResourceType = typeof(Texts))]
        [ColorPicker]
        public Color Color { get => color; set => Set(ref color, value); }
        Color color = Colors.White;

        [Display(Name = nameof(Texts.BackgroundColor), ResourceType = typeof(Texts))]
        [ColorPicker]
        public Color BackgroundColor { get => backgroundColor; set => Set(ref backgroundColor, value); }
        Color backgroundColor = Colors.Black;

        [Display(Name = nameof(Texts.FeatherWidth), ResourceType = typeof(Texts))]
        [AnimationSlider("F0", "px", 0, 500)]
        public Animation FeatherWidth { get; } = new Animation(50, 1, YMM4Constants.MaximumBitmapSize / 4);

        [Display(Name = nameof(Texts.ShaftWidth), ResourceType = typeof(Texts))]
        [AnimationSlider("F0", "px", 0, 500)]
        public Animation ShaftWidth { get; } = new Animation(5, 0, YMM4Constants.MaximumBitmapSize / 2);

        [Display(Name = nameof(Texts.Height), ResourceType = typeof(Texts))]
        [AnimationSlider("F0", "px", 0, 500)]
        public Animation Height { get; } = new Animation(100, 1, YMM4Constants.MaximumBitmapSize / 2);

        [Display(Name = nameof(Texts.Point), ResourceType = typeof(Texts))]
        [AnimationSlider("F0", "px", 0, 500)]
        public Animation Point { get; } = new Animation(50, 0, YMM4Constants.VeryLargeValue);

        [Display(Name = nameof(Texts.Zoom), ResourceType = typeof(Texts), Order = 250)]
        [AnimationSlider("F1", "%", 0, 400)]
        public Animation Zoom { get; } = new Animation(100, 0, YMM4Constants.VeryLargeValue);

        public override IBrushSource CreateBrush(IGraphicsDevicesAndContext devices)
        {
            return new ArrowPatternBrushSource(devices, this);
        }

        protected override IEnumerable<IAnimatable> GetAnimatables() => base.GetAnimatables().Concat([FeatherWidth, ShaftWidth, Height, Point, Zoom]);
    }
}
