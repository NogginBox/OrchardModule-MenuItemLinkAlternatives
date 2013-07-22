using System;
using System.Collections.Generic;
using Orchard.DisplayManagement.Implementation;

namespace NogginBox.MenuItemLinkAlternates
{
	public class MenuItemLinkAlternatesFactory : ShapeDisplayEvents
	{
		public override void Displaying(ShapeDisplayingContext context) {
			context.ShapeMetadata.OnDisplaying(displayedContext => {
				var alternates = displayedContext.ShapeMetadata.Alternates;
				switch (displayedContext.ShapeMetadata.Type) {
					case "Parts_MenuWidget":
						var zoneName = displayedContext.Shape.ContentItem.WidgetPart.Zone;
						displayedContext.Shape.Menu.Zone = zoneName;
						break;
					case "Menu":
						AddAlternates(alternates, displayedContext.Shape.Zone, "Menu");
						break;
					case "MenuItem":
						AddAlternates(alternates, displayedContext.Shape.Parent.Zone, "MenuItem");
						break;
					case "MenuItemLink":
						AddAlternates(alternates, displayedContext.Shape.Parent.Zone, "MenuItemLink");
						break;
				}
			});
		}

		private static void AddAlternates(IList<String> alternateCollection, String zoneName, String shapeName) {
			alternateCollection.Add(shapeName + "__" + zoneName);
			//alternateCollection.Add(shapeName + "__" + contentTypeName + "__" + zoneName);
		}
	}
}