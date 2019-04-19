using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace QWERTY.Models
{
    public class User
    {
        public string displayName { get; set; }
    }

    public class CreatedBy
    {
        public User user { get; set; }
    }

    public class User2
    {
        public string displayName { get; set; }
    }

    public class LastModifiedBy
    {
        public User2 user { get; set; }
    }

    public class ParentReference
    {
        public string siteId { get; set; }
    }

    public class ContentType
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class PublishingState
    {
        public string level { get; set; }
        public string versionId { get; set; }
    }

    public class Value
    {
        [JsonProperty("eTag")]
        public string ETag { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lastModifiedDateTime")]
        public DateTime LastModifiedDateTime { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("webUrl")]
        public string WebUrl { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("pageLayout")]
        public string PageLayout { get; set; }

        [JsonProperty("createdBy")]
        public CreatedBy CreatedBy { get; set; }

        [JsonProperty("lastModifiedBy")]
        public LastModifiedBy LastModifiedBy { get; set; }

        [JsonProperty("parentReference")]
        public ParentReference ParentReference { get; set; }

        [JsonProperty("contentType")]
        public ContentType ContentType { get; set; }

        [JsonProperty("webParts")]
        public List<object> WebParts { get; set; }

        [JsonProperty("publishingState")]
        public PublishingState PublishingState { get; set; }

    }

}






