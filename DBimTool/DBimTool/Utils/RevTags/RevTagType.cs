using DBimTool.Utils.FilterElementsInRevit;

namespace DBimTool.Utils.RevTags
{
    public class RevTagType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static List<RevTagType> GetRevTagTypes(Document document, BuiltInCategory builtInCategoryTag)
        {
            try
            {
                var sbs = document.GetElementsFromCategory<FamilySymbol>(builtInCategoryTag);
                if (!sbs.Any()) throw new Exception();
                return sbs
                    .Select(x => new RevTagType() { Id = int.Parse(x.Id.ToString()), Name = x.Name })
                    .ToList();
            }
            catch (Exception)
            {
            }
            return new List<RevTagType>();
        }
    }
}
