using Skybrud.Social.Json;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Google.MyBusiness.Objects {

    public class GenericListResponse<T> : GoogleApiResource {

        #region Properties

        public string NextPageToken { get; set; }

        public string PrevPageToken { get; set; }        

        public IEnumerable<T> Items { get; set; }

        #endregion

        #region Constructors

        protected GenericListResponse(JsonObject obj) : base(obj) { }

        #endregion
        
        #region Static methods
       
        public static GenericListResponse<T> Parse(JsonObject obj, System.Func<JsonObject, T> itemParse, string itemsFieldName = "items") {
            if (obj == null) return null;
            return new GenericListResponse<T>(obj) {
                NextPageToken = obj.GetString("nextPageToken"),
                PrevPageToken = obj.GetString("prevPageToken"),                
                Items = obj.GetArray(itemsFieldName, itemParse)
            };
        }

        public void AppendItems(IEnumerable<T> items)
        {
            if (items == null) return;
            EnsureItemsNotNull();
            ((List<T>)Items).AddRange(items);
        }

        public int CountBody()
        {
            EnsureItemsNotNull();
            return Items.Count();
        }

        /// <summary>
        /// Ensure only get [count] of data
        /// </summary>
        /// <param name="count"></param>
        public void EnsureItemsCount(int count)
        {
            EnsureItemsNotNull();
            Items = Items.Take(count).ToList();
        }

        private void EnsureItemsNotNull()
        {
            if (Items == null)
            {
                Items = new List<T>();
            }
        }

        #endregion

    }

}