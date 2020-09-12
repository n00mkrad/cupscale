using System;
using System.Drawing;
using System.Windows.Forms;
using Cyotek.Windows.Forms;

namespace Cupscale
{
	internal class UIHelpers
	{
		public static void InitCombox(ComboBox box, int index)
		{
			if (box.Items.Count >= 1)
			{
				box.SelectedIndex = index;
				box.Text = box.Items[index].ToString();
			}
		}

		public static void FillModelComboBox(ComboBox box, bool resetIndex = false)
		{
			EsrganData.ReloadModelList();
			box.Items.Clear();
			foreach (string model in EsrganData.models)
			{
				box.Items.Add(model);
			}
			if (resetIndex || string.IsNullOrEmpty(box.Text))
			{
				InitCombox(box, 0);
			}
		}

		public static void ReplaceImageAtSameScale(ImageBox imgBox, Image newImg)
		{
			Logger.Log("Replacing image on " + imgBox.Name + " with new image (" + newImg.Width + "x" + newImg.Height + ")");
			float num = (float)imgBox.Image.Width / (float)newImg.Width;
			float num2 = (float)imgBox.AutoScrollPosition.X / num;
			float num3 = (float)imgBox.AutoScrollPosition.Y / num;
			if (num2 < 0f)
			{
				num2 *= -1f;
			}
			if (num3 < 0f)
			{
				num3 *= -1f;
			}
			num2 *= num;
			num3 *= num;
			imgBox.Image = newImg;
			imgBox.Zoom = (int)Math.Round((float)imgBox.Zoom * num);
			Point autoScrollPosition = imgBox.AutoScrollPosition;
			autoScrollPosition.X = (int)num2;
			autoScrollPosition.Y = (int)num3;
			imgBox.AutoScrollPosition = autoScrollPosition;
		}
	}
}
