using DBimTool.Utils.Compares;
using DBimTool.Utils.Geometries;
using DBimTool.Utils.NumberUtils;
using DBimTool.Utils.RevCurves;
using DBimTool.Utils.RevFaces;

namespace DBimTool.Utils.RevGrids
{
    public static class RevGridUtils
    {
        public static void ConfigGridOnViewPlan(this List<Grid> grids, ViewPlan viewPlan)
        {
            try
            {
                var extent = 20.MmToFoot();
                var document = viewPlan.Document;
                var viewTemplate = document.GetElement(viewPlan.ViewTemplateId) as View;
                var scale = viewTemplate == null
                    ? viewPlan.Scale
                    : viewTemplate.Scale;
                var gridsGroup = grids
                    .Select(x => x)
                    .GroupBy(x => x, new CompareGrid(viewPlan))
                    .Select(x => x.ToList().Distinct(new CompareGridOverLap(viewPlan)).ToList())
                    .OrderByDescending(x => x.Count)
                    .ToList();
                var qGridGroup = gridsGroup.Count;
                if (qGridGroup < 2) return;
                var grs1 = gridsGroup[0].Select(x => x as DatumPlane).ToList();
                var grs2 = gridsGroup[1].Select(x => x as DatumPlane).ToList();
                var gr1Dir = grs1.FirstOrDefault().GetCurvesInView(DatumExtentType.ViewSpecific, viewPlan).ElementAt(0).Direction();
                var gr2Dir = grs2.FirstOrDefault().GetCurvesInView(DatumExtentType.ViewSpecific, viewPlan).ElementAt(0).Direction();

                var ps1Sort = grs1
                    .OrderBy(x =>
                    {
                        var mp = x.GetCurvesInView(DatumExtentType.ViewSpecific, viewPlan).ElementAt(0).Mid();
                        return Math.Round(mp.DotProduct(gr2Dir).FootToMm(), 0);
                    });
                var ps2Sort = grs2
                    .OrderBy(x =>
                    {
                        var mp = x.GetCurvesInView(DatumExtentType.ViewSpecific, viewPlan).ElementAt(0).Mid();
                        return Math.Round(mp.DotProduct(gr1Dir).FootToMm(), 0);
                    });
                var ps1SortStartFace = new FaceCustom(gr2Dir, ps1Sort.FirstOrDefault().GetCurvesInView(DatumExtentType.ViewSpecific, viewPlan).ElementAt(0).Mid());
                var ps1SortEndFace = new FaceCustom(gr2Dir, ps1Sort.LastOrDefault().GetCurvesInView(DatumExtentType.ViewSpecific, viewPlan).ElementAt(0).Mid());
                var ps2SortStartFace = new FaceCustom(gr1Dir, ps2Sort.FirstOrDefault().GetCurvesInView(DatumExtentType.ViewSpecific, viewPlan).ElementAt(0).Mid());
                var ps2SortEndFace = new FaceCustom(gr1Dir, ps2Sort.LastOrDefault().GetCurvesInView(DatumExtentType.ViewSpecific, viewPlan).ElementAt(0).Mid());

                foreach (var gr in grs1)
                {
                    var lcr = gr.GetCurvesInView(DatumExtentType.ViewSpecific, viewPlan).ElementAt(0);

                    var p1 = lcr.Mid().RayPointToFace(gr1Dir, ps2SortEndFace) + gr1Dir * extent * scale;
                    var p2 = lcr.Mid().RayPointToFace(gr1Dir, ps2SortStartFace) - gr1Dir * extent * scale;

                    var l = Line.CreateBound(p1, p2);
                    gr.SetCurveInView(DatumExtentType.ViewSpecific, viewPlan, l);
                }
                foreach (var gr in grs2)
                {
                    var lcr = gr.GetCurvesInView(DatumExtentType.ViewSpecific, viewPlan).ElementAt(0);

                    var p1 = lcr.Mid().RayPointToFace(gr2Dir, ps1SortEndFace) + gr2Dir * extent * scale;
                    var p2 = lcr.Mid().RayPointToFace(gr2Dir, ps1SortStartFace) - gr2Dir * extent * scale;

                    var l = Line.CreateBound(p1, p2);
                    gr.SetCurveInView(DatumExtentType.ViewSpecific, viewPlan, l);
                }

            }
            catch (Exception)
            {
            }
        }
    }
}
