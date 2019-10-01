using InserimentoDatiCroceRossa.DbModel;
using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InserimentoDatiCroceRossa.DbServiceObjects
{
    public class PathologyService
    {
        public List<PathologyEntity> GetAllPathologies()
        {
            List<Pat> patDbList = new List<Pat>();
            List<PathologyEntity> pathologies = new List<PathologyEntity>();

            using (var db = new CroceRossaEntities())
            {
                patDbList = db.Pat.ToList();
            }
            patDbList.ForEach(pat => { pathologies.Add(pat.toPathologyEntity()); });
            return pathologies;
        }

        public PathologyEntity GetPathologyById(int pathologyId)
        {
            PathologyEntity pathology = new PathologyEntity(); 

            if (pathologyId > 0)
            {
                using (var db = new CroceRossaEntities())
                {
                    var pat = db.Pat.FirstOrDefault(x => x.PatOwnId == pathologyId);
                    pathology = pat == null ? new PathologyEntity() : pat.toPathologyEntity();
                }
            }
            return pathology;
        }
        public int Add(PathologyEntity pathology)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    db.Pat.Add(pathology.ToPat());
                    db.SaveChanges();

                    return 0;
                }
            }
            catch
            {
                return -1;
            }
        }

        public int Update(PathologyEntity pathology)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Pat pat = db.Pat.First(x => x.PatOwnId == pathology.Id);
                    if (pat != null)
                    {
                        pat = pathology.ToPat(pat);
                        db.SaveChanges();
                    }
                    return 0;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Delete(PathologyEntity pathology)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Pat pat = db.Pat.First(x => x.PatOwnId == pathology.Id);
                    if (pat != null)
                    {
                        db.Pat.Remove(pat);
                        db.SaveChanges();
                    }
                    return 0;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }        
    }
    public static class PatDbMapper
    {
        public static Pat ToPat(this PathologyEntity pathology, Pat pat = null)
        {
            if (pat == null) pat = new Pat();

            pat.PatOwnId = pathology.Id;
            pat.PatNam = pathology.PathologyName;

            return pat;
        }

        public static PathologyEntity toPathologyEntity(this Pat pat)
        {
            return new PathologyEntity()
            {
                Id = pat.PatOwnId,
                PathologyName = pat.PatNam
            };
        }
    }
}
