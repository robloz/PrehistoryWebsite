using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrehistoryWebsite.Common;
using PrehistoryWebsite.Domain.Abstract;

// http://www.asp.net/mvc/overview/older-versions-1/nerddinner/enable-automated-unit-testing
namespace PrehistoryWebsite.Domain.Fake
{
    class FakeRepository : IRepository
    {
        #region IRepository Members

        List<Tag> listTag;
        List<IndexTemplate> listIndexTemplate;
        List<BlankTemplate> listBlankTemplate;
        List<PostTemplate> listPostTemplate;
        List<GalleryTemplate> listGalleryTemplate;

        List<tbl_urlSlugger> listUrlSlugger;

        public FakeRepository()
        {
            listTag = new List<Tag>();

            for (int i = 0; i < 10; i++)
            {
                listTag.Add(new Tag { id = i + 1, nameTag = "tag" + i, urlSlug = "tag" + i, descriptionTag = "description tag " + 1 });
            }

            listUrlSlugger = new List<tbl_urlSlugger>();

            listIndexTemplate = new List<IndexTemplate>{

                new IndexTemplate{id=1, namePage="IndexTemplate1"},
                new IndexTemplate{id=2, namePage="IndexTemplate2"},
                new IndexTemplate{id=3, namePage="IndexTemplate3"},
                new IndexTemplate{id=4, namePage="IndexTemplate4"}
            };

            foreach(var template in listIndexTemplate){

                listUrlSlugger.Add(new tbl_urlSlugger{ nameItem = template.namePage});
                template.UrlSlugger = listUrlSlugger[listUrlSlugger.Count-1];
                template.refTemplateItem = listUrlSlugger.Count - 1;
            }

            listBlankTemplate = new List<BlankTemplate>{

                new BlankTemplate{id=1, namePage="BlankTemplate1"},
                new BlankTemplate{id=2, namePage="BlankTemplate2"},
                new BlankTemplate{id=3, namePage="BlankTemplate3"},
                new BlankTemplate{id=4, namePage="BlankTemplate4"}
            };

            foreach (var template in listBlankTemplate)
            {

                listUrlSlugger.Add(new tbl_urlSlugger { nameItem = template.namePage });
                template.UrlSlugger = listUrlSlugger[listUrlSlugger.Count - 1];
                template.refTemplateItem = listUrlSlugger.Count - 1;
            }

            listPostTemplate = new List<PostTemplate>{

                new PostTemplate{id=1, namePage="PostTemplate1"},
                new PostTemplate{id=2, namePage="PostTemplate2"},
                new PostTemplate{id=3, namePage="PostTemplate3"},
                new PostTemplate{id=4, namePage="PostTemplate4"}
            };

            foreach (var template in listPostTemplate)
            {

                listUrlSlugger.Add(new tbl_urlSlugger { nameItem = template.namePage });
                template.UrlSlugger = listUrlSlugger[listUrlSlugger.Count - 1];
                template.refTemplateItem = listUrlSlugger.Count - 1;
            }

            listGalleryTemplate = new List<GalleryTemplate>{

                new GalleryTemplate{id=1, namePage="GalleryTemplate1"},
                new GalleryTemplate{id=2, namePage="GalleryTemplate2"},
                new GalleryTemplate{id=3, namePage="GalleryTemplate3"},
                new GalleryTemplate{id=4, namePage="GalleryTemplate4"}
            };

            foreach (var template in listGalleryTemplate)
            {

                listUrlSlugger.Add(new tbl_urlSlugger { nameItem = template.namePage });
                template.tbl_urlSlugger1 = listUrlSlugger[listUrlSlugger.Count - 1];
                template.refTemplateItem = listUrlSlugger.Count - 1;
            }

        }

        public IEnumerable<Tag> Tags
        {
            get {return listTag;}
            set {listTag = new List<Tag>(value);}
        }

        public IEnumerable<Category> Categories
        {
            get;
            set;
        }

        public IEnumerable<Post> Posts
        {
            get;
            set;
        }

        public IEnumerable<Comment> Comments
        {
            get;
            set;
        }

        public IEnumerable<FolderWeb> folders
        {
            get;
            set;
        }

        public IEnumerable<FileWeb> files
        {
            get;
            set;
        }

        public IEnumerable<Slideshow> slideShow
        {
            get;
            set;
        }

        public IEnumerable<Message> Messages
        {
            get;
            set;
        }

        public Footer footer
        {
            get;
            set;
        }

        public Advertisement Advertisement
        {
            get;
            set;
        }

        public SlideshowProperties SlideShowProperties
        {
            get;
            set;
        }

        public IEnumerable<IndexTemplate> IndexTemplate
        {
            get { return listIndexTemplate; }

        }

        public IEnumerable<BlankTemplate> BlankTemplate
        {
            get { return listBlankTemplate; }
        }

        public IEnumerable<PostTemplate> PostTemplate
        {
            get { return listPostTemplate; }
        }

        public IEnumerable<Menu> Menu
        {
            get;
            set;
        }

        public IEnumerable<tbl_urlSlugger> UrlSlugger
        {
            get { return listUrlSlugger; }
        }

        public Tag Find(string urlSlug)
        {

            return Tags.SingleOrDefault(x => x.urlSlug == urlSlug);

        }

        public Tag Find(int id)
        {
            return Tags.SingleOrDefault(x => x.id == id);
        }

        public void Save(Tag tag)
        {
            listTag.Add(tag);
        }

        public void Delete(Tag tag)
        {
            listTag.Remove(tag);
        }

        public string[] GetNameTags()
        {

            List<string> tags = new List<string>();

            foreach (Tag t in Tags)
            {
                tags.Add(t.nameTag);
            }

            return tags.ToArray();
        }

        public Category FindCategory(string urlSlug)
        {
            throw new NotImplementedException();
        }

        public Category FindCategory(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Category cat)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category cat)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int catid)
        {
            throw new NotImplementedException();
        }

        public Post FindPost(string urlSlug)
        {
            throw new NotImplementedException();
        }

        public Post FindPost(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Post post)
        {
            throw new NotImplementedException();
        }

        public void Delete(Post post)
        {
            throw new NotImplementedException();
        }

        public void SetTagsToPost(Post post, IEnumerable<Tag> tags)
        {
            throw new NotImplementedException();
        }

        public bool HasTag(Post post, int idTag)
        {
            throw new NotImplementedException();
        }

        public Comment FindComment(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public FolderWeb FindFolder(string name)
        {
            throw new NotImplementedException();
        }

        public void Save(FolderWeb folder)
        {
            throw new NotImplementedException();
        }

        public void Delete(FolderWeb folder)
        {
            throw new NotImplementedException();
        }

        public FileWeb FindFile(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(FileWeb file)
        {
            throw new NotImplementedException();
        }

        public void Delete(FileWeb file)
        {
            throw new NotImplementedException();
        }

        public Slideshow FindSlideShow(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Slideshow sliderShow)
        {
            throw new NotImplementedException();
        }

        public void Delete(Slideshow sliderShow)
        {
            throw new NotImplementedException();
        }

        public void DeleteSlideShow(int ide)
        {
            throw new NotImplementedException();
        }

        public void Save(SlideshowProperties slideshowProperties)
        {
            throw new NotImplementedException();
        }

        public void Save(Footer footer)
        {
            throw new NotImplementedException();
        }

        public void Save(Advertisement ad)
        {
            throw new NotImplementedException();
        }

        public Message FindMessage(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Message message)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message message)
        {
            throw new NotImplementedException();
        }

        public IndexTemplate FindIndexTemplate(int id)
        {
            try
            {
                return IndexTemplate.Single(x => x.id == id);
            }
            catch
            {
                return null;
            }
        }

        public BlankTemplate FindBlankTemplate(int id)
        {
            try
            {
                return listBlankTemplate.Single(x => x.id == id);
            }
            catch
            {
                return null;
            }
        }

        public PostTemplate FindPostTemplate(int id)
        {
            try
            {
                return listPostTemplate.Single(x => x.id == id);
            }
            catch
            {
                return null;
            }
        }

        public void Save(IndexTemplate template)
        {
            // search the tag and update it
            IndexTemplate templateToUpdate = FindIndexTemplate(template.id);

            if (templateToUpdate != null)
            {

                templateToUpdate.title1 = template.title1;
                templateToUpdate.descriptionTitle1 = template.descriptionTitle1;

                templateToUpdate.title2 = template.title2;
                templateToUpdate.descriptionTitle2 = template.descriptionTitle2;

                templateToUpdate.title3 = template.title3;
                templateToUpdate.descriptionTitle3 = template.descriptionTitle3;

                templateToUpdate.title4 = template.title4;
                templateToUpdate.descriptionTitle4 = template.descriptionTitle4;

                templateToUpdate.SEO_title = template.SEO_title;
                templateToUpdate.SEO_description = template.SEO_description;
                templateToUpdate.SEO_keywords = template.SEO_keywords;
                templateToUpdate.namePage = template.namePage;

                templateToUpdate.UrlSlugger.nameItem = template.UrlSlugger.nameItem;
            }
            else
            {


                listIndexTemplate.Add(template);
                //listUrlSlugger.Add(template.UrlSlugger);

            }
        }

        public void Save(BlankTemplate template)
        {
            // search the tag and update it
            BlankTemplate templateToUpdate = FindBlankTemplate(template.id);

            if (templateToUpdate != null)
            {

                templateToUpdate.descriptionBlank = template.descriptionBlank;


                templateToUpdate.SEO_title = template.SEO_title;
                templateToUpdate.SEO_description = template.SEO_description;
                templateToUpdate.SEO_keywords = template.SEO_keywords;
                templateToUpdate.namePage = template.namePage;

                templateToUpdate.UrlSlugger.nameItem = template.UrlSlugger.nameItem;
            }
            else
            {
                listBlankTemplate.Add(template);
            }
        }

        public void Save(PostTemplate template)
        {
            // search the tag and update it
            PostTemplate templateToUpdate = FindPostTemplate(template.id);

            if (templateToUpdate != null)
            {

                templateToUpdate.title = template.title;
                templateToUpdate.idCategory = template.idCategory;

                templateToUpdate.SEO_title = template.SEO_title;
                templateToUpdate.SEO_description = template.SEO_description;
                templateToUpdate.SEO_keywords = template.SEO_keywords;
                templateToUpdate.namePage = template.namePage;

                templateToUpdate.UrlSlugger.nameItem = template.UrlSlugger.nameItem;
            }
            else
            {
                listPostTemplate.Add(template);
            }
        }

        public int SetElments(int number, int? parent)
        {
            throw new NotImplementedException();
        }

        public void Delete(Menu menu)
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable<Menu> menus)
        {
            throw new NotImplementedException();
        }

        public string FindPageNameFromMenu(int idMenu)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IRepository Members


        public MenuProperties MenuProperties
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region IRepository Members


        public void Save(MenuProperties menuProperties)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IRepository Members


        public IEnumerable<GalleryTemplate> GalleryTemplate
        {
            get { return listGalleryTemplate; }
        }

        public GalleryTemplate FindGalleryTemplate(int id)
        {
            try
            {
                return listGalleryTemplate.Single(x => x.id == id);
            }
            catch
            {
                return null;
            }
        }

        public void Save(GalleryTemplate template)
        {
            // search the tag and update it
            GalleryTemplate templateToUpdate = FindGalleryTemplate(template.id);

            if (templateToUpdate != null)
            {
                string oldNamePage = templateToUpdate.namePage;

                // change template
                templateToUpdate.title = template.title;
                templateToUpdate.SEO_title = template.SEO_title;
                templateToUpdate.SEO_description = template.SEO_description;
                templateToUpdate.SEO_keywords = template.SEO_keywords;
                templateToUpdate.namePage = template.namePage;
                // change urlSluger
                tbl_urlSlugger urlSluger = UrlSlugger.SingleOrDefault(x => x.nameItem == oldNamePage);

                if (urlSluger != null)
                {
                    urlSluger.nameItem = template.namePage;
                }
            }
            else
            {
               listGalleryTemplate.Add(template);
            }
        }

        #endregion

        #region IRepository Members


        public void DeleteImageGalleryTemplate(int idTemplateGallery, int idImage)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IRepository Members


        public void AddImageGalleryTemplate(int idTemplateGallery, string path)
        {
            throw new NotImplementedException();
        }

        #endregion




        public bool IsUrlSluggerRepeat(string name)
        {
            try
            {
                // return exception if there are more than one or it's not in the database
                IEnumerable<tbl_urlSlugger> list = UrlSlugger.Where(x => UrlSluggerGenerator.ToUrlSlug(x.nameItem) == UrlSluggerGenerator.ToUrlSlug(name));

                if (list.Count() == 0)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }



        #region IRepository Members


        public void Delete(IndexTemplate template)
        {
            throw new NotImplementedException();
        }

        public void Delete(BlankTemplate template)
        {
            throw new NotImplementedException();
        }

        public void Delete(PostTemplate template)
        {
            throw new NotImplementedException();
        }

        public void Delete(GalleryTemplate template)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
