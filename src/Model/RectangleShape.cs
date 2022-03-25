﻿using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace Draw
{
	/// <summary>
	/// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
	/// </summary>
	
	[Serializable]
	public class RectangleShape : Shape
	{
		#region Constructor
		
		public RectangleShape(RectangleF rect) : base(rect)
		{
		}
		
		public RectangleShape(RectangleShape rectangle) : base(rectangle)
		{
		}
		
		#endregion

		/// <summary>
		/// Проверка за принадлежност на точка point към правоъгълника.
		/// В случая на правоъгълник този метод може да не бъде пренаписван, защото
		/// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
		/// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
		/// елемента в този случай).
		/// </summary>
		public override bool Contains(PointF point)
		{
			if (base.Contains(point))
				// Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
				// В случая на правоъгълник - директно връщаме true
				return true;
			else
				// Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
				return false;
		}
		
		/// <summary>
		/// Частта, визуализираща конкретния примитив.
		/// </summary>
		public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);
			
			grfx.FillRectangle(new SolidBrush(FillColor),Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			grfx.DrawRectangle(new Pen(StrokeColor, StrokeWidth),Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Height", Height);
			info.AddValue("Width", Width);
			info.AddValue("Location", Location);

			info.AddValue("FillColor", FillColor);
			info.AddValue("StrokeColor", StrokeColor);
			info.AddValue("StrokeWidth", StrokeWidth);
		}

		public RectangleShape(SerializationInfo info, StreamingContext context)
		{
			Height = (float)info.GetValue("Height", typeof(float));
			Width = (float)info.GetValue("Width", typeof(float));
			Location = (PointF)info.GetValue("Location", typeof(PointF));

			FillColor = (Color)info.GetValue("FillColor", typeof(Color));
			StrokeColor = (Color)info.GetValue("StrokeColor", typeof(Color));
			StrokeWidth = (int)info.GetValue("StrokeWidth", typeof(int));
		}
	}
}
