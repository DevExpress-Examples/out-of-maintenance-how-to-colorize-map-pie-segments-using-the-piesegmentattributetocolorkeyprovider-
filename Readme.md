<!-- default file list -->
*Files to look at*:

* **[Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))**
<!-- default file list end -->
# How to colorize map pie segments using the PieSegmentAttributeToColorKeyProvider class


The following example shows how to colorize map pie segments using the <strong>PieSegmentAttributeToColorKeyProvider</strong> class as a color information provider for the colorizer.<br />For this, create a <strong>PieSegmentAttributeToColorKeyProvider</strong> object. Specify the <strong>PieSegmentAttributeToColorKeyProvider.AttributeName</strong> property value as a pie segment attribute name. Then assign the object to the <strong>KeyValueColorizer.ColorItemKeyProvider</strong> property. <br />Create a few <a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapColorizerColorTextItemtopic">ColorizerColorTextItem</a> objects with keys, which  represent values of an attribute of pie segments, and add them to the colorizer via the <strong>KeyValueColorizer.AddItem</strong> method.

<br/>


