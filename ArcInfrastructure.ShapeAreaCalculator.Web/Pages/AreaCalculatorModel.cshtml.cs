using ArcInfrastructure.ShapeAreaCalculator.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace ArcInfrastructure.ShapeAreaCalculator.Web.Pages
{
    public class AreaCalculatorModel : PageModel
    {
        private IShapeFactory _shapeFactory;

        [FromQuery(Name = "shape-key")]
        public string SelectedShapeKey { get; set; }

        public IReadOnlyList<string> ShapeKeys => _shapeFactory.GetShapes();

        public IReadOnlyList<string> DimensionKeys => SelectedShapeKey != null ? _shapeFactory.GetDimensionKeys(SelectedShapeKey) : null;

        public bool IsShapeSelected(string shapeKey) => SelectedShapeKey != null && shapeKey == SelectedShapeKey;

        public double? Area { get; set; }

        public AreaCalculatorModel(IShapeFactory shapeFactory)
        {
            _shapeFactory = shapeFactory;
        }

        public void OnPost()
        {
            var dimensions = DimensionKeys.ToDictionary(k => k, k => double.Parse(Request.Form[k]));

            Area = _shapeFactory.CreateShape(SelectedShapeKey, dimensions).Area();
        }
    }
}
