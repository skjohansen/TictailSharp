using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TictailSharp.Api.Implentation;
using TictailSharp.Api.Model.Order;
using TictailSharp.Api.Resources;
using TictailSharp.Api.Test.TestImplementation;
using Xunit;

namespace TictailSharp.Api.Test
{
    public class OrderResourceTest : IOrderResource
    {
        #region Interface
        public IEnumerator<Order> GetEnumerator()
        {
            throw new NotImplementedException("No test needed");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Order> GetRange()
        {
            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"), "accesstoken_abcdefhiljklmnopqrstuvxuz");
            var clientTest = new TictailClientTest(endpointDummy);

            // Prepare store content
            clientTest.Content = "{" +
                        "\"id\": \"myStore\"," +
                      "}";

            var repository = new TictailRepository(clientTest);
            var store = repository.Stores["somestore"];

            // Prepare followers content
            clientTest.Content =  "[" + "{" +
                "\"id\":\"123abc\"," +
                "},"+
            "{" +
                "\"id\":\"bcd123\"," +
            "}" +
                "]";
            return store.Orders.GetRange();
        }

        public IEnumerator<Order> DeserializeRangeGet(string value)
        {
            var repository = new OrderResource(new TictailClientTest(), "abc");
            return repository.DeserializeRangeGet(value);
        }

        public Order Get(string idOrHref)
        {
            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"), "accesstoken_abcdefhiljklmnopqrstuvxuz");
            var clientTest = new TictailClientTest(endpointDummy);

            // Prepare store content
            clientTest.Content = "{" +
                        "\"id\": \"myStore\"," +
                      "}";

            var repository = new TictailRepository(clientTest);
            var store = repository.Stores["somestore"];

            // Prepare product content
            clientTest.Content = "{" +
                        "\"id\": \"" + idOrHref + "\"" +
                    "}";
            return store.Orders.Get(idOrHref);
        }

        public Order DeserializeGet(string value)
        {
            var repository = new OrderResource(new TictailClientTest(), "abc");
            return repository.DeserializeGet(value);
        }

        public Order this[string idOrHref]
        {
            get { throw new NotImplementedException("No test needed"); }
        }

        public string StoreId { get; set; }
        #endregion

        #region Test

        [Fact]
        public void Get_Ok_Order()
        {
            var order = Get("1234");
            Assert.Equal("1234", order.Id);
        }

        [Fact]
        public void GetRange_Ok_Order()
        {
            var orders = GetRange();
            var orderList = Cast<Order>(orders).ToList();
            Assert.Equal(2, orderList.Count);
            Assert.Equal("123abc", orderList[0].Id);
            Assert.Equal("bcd123", orderList[1].Id);
        }

        [Fact]
        public void DeserializeGet_Ok_Order2()
        {
            #region Data
            const string tictailJsonReponse = 
  "{"+
    "\"customer\": {"+
      "\"name\": \"Cust omer\", "+
      "\"language\": \"en\", "+
      "\"country\": \"SE\", "+
      "\"created_at\": \"2013-01-18T08:03:01\", "+
      "\"modified_at\": null, "+
      "\"id\": \"yUM\", "+
      "\"email\": \"cust.omer@gmail.com\""+
    "}, "+
    "\"transaction\": {"+
      "\"status\": \"paid\", "+
      "\"paid_at\": \"2014-09-01T14:09:08\", "+
      "\"reference\": \"2KY73837924000X\", " +
      "\"processor\": \"paypal\""+
    "}, "+
    "\"prices_include_vat\": true, "+
    "\"discounts\": ["+
      "{"+
        "\"status\": \"published\", "+
        "\"minimum_price\": 0, "+
        "\"type\": \"money_off\","+ 
        "\"created_at\": \"2014-07-02T02:15:35\", "+
        "\"title\": \"Discout name\", "+
        "\"modified_at\": \"2014-08-02T10:24:45\", "+
        "\"currency\": \"SEK\", "+
        "\"amount\": 100, "+
        "\"storewide\": true,"+ 
        "\"applicable_to\": {"+
          "\"products\": [], "+
          "\"categories\": []"+
        "}, "+
        "\"id\": \"6yt\""+
      "}"+
    "], " +
            #region items
 "\"items\": [" +
      "{"+
        "\"currency\": \"SEK\", "+
        "\"price\": 52000, "+
        "\"product\": {"+
          "\"status\": \"published\", "+
          "\"store_url\": null, "+
          "\"description\": \"Sovshorts&nbsp;smalrandiga sovshorts. Dekorativ spetskant \nnedtill, res\u00e5r i midjan samt ett band att knyta. Sovshortsen \u00e4r \ntillverkade i exklusivt Italiensk tyg av mycket god kvalitet. \nSovshortsen \u00e4r normala i storleken.<br><i><br>\\\"Fanny Castelius producerar eleganta och tidl\u00f6sa kl\u00e4desplagg med de mest kvalitativa av tyger f\u00f6r kvinnor som vill utstr\u00e5la sin inre elegans och sk\u00f6nhet. Fanny Castelius tror p\u00e5</i><i>&nbsp;p\u00e5 att denna kvinna alltid \u00e4r en sk\u00f6nhet, b\u00e5de i fram och i motg\u00e5ng.\\\"</i><br><br>\", "+
          "\"store_name\": null, "+
          "\"store_id\": \"nh6\", "+
          "\"unlimited\": true, "+
          "\"created_at\": \"2014-08-11T21:12:14\", "+
          "\"title\": \"Fanny Castelius - Sovshorts Ljusrosa\", "+
          "\"modified_at\": \"2014-09-09T04:02:18\", "+
          "\"variation\": {"+
            "\"title\": \"36\", "+
            "\"modified_at\": \"2014-09-09T10:20:40\", "+
            "\"created_at\": \"2011-01-20T22:13:55\", "+
            "\"unlimited\": true, "+
            "\"id\": \"KUyy\", " +
            "\"quantity\": null"+
          "}, "+
          "\"slug\": \"fanny-castelius-sovshorts-ljusrosa\", "+
          "\"price\": 74100, "+
          "\"currency\": \"SEK\", "+
          "\"images\": ["+
            "{"+
              "\"original_height\": 235, "+
              "\"sizes\": {"+
                "\"2000\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/98765.jpeg?size=2000\", "+
                "\"30\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/98765.jpeg?size=30\", "+
                "\"300\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/98765.jpeg?size=300\", "+
                "\"45\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/98765.jpeg?size=45\", "+
                "\"50\": \"https://dtvep25tfu0n1.cloudfront.net/i/product/50/0/98765.jpeg\", "+
                "\"40\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/98765.jpeg?size=40\", "+
                "\"640\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/98765.jpeg?size=640\", "+
                "\"75\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/98765.jpeg?size=75\", "+
                "\"100\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/98765.jpeg?size=100\", "+
                "\"500\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/98765.jpeg?size=500\", "+
                "\"1000\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/98765.jpeg?size=1000\""+
              "}, "+
              "\"url\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/98765.jpeg\", "+
              "\"created_at\": \"2014-09-22T20:23:04\", "+
              "\"modified_at\": \"2014-09-22T20:23:04\", "+
              "\"original_width\": 254, "+
              "\"id\": \"ki9u\""+
            "}, "+
            "{"+
              "\"original_height\": 235, "+
              "\"sizes\": {"+
                "\"2000\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/45678.jpeg?size=2000\", "+
                "\"30\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/45678.jpeg?size=30\", "+
                "\"300\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/45678.jpeg?size=300\", "+
                "\"45\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/45678.jpeg?size=45\", "+
                "\"50\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/45678.jpeg?size=50\", "+
                "\"40\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/45678.jpeg?size=40\", "+
                "\"640\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/45678.jpeg?size=640\", "+
                "\"75\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/45678.jpeg?size=75\", "+
                "\"100\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/45678.jpeg?size=100\", "+
                "\"500\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/45678.jpeg?size=500\", "+
                "\"1000\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/45678.jpeg?size=1000\""+
              "}, "+
              "\"url\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/45678.jpeg\", "+
              "\"created_at\": \"2014-09-22T20:23:04\", "+
              "\"modified_at\": \"2014-09-22T20:23:04\", "+
              "\"original_width\": 1457, "+
              "\"id\": \"kli9u\""+
            "}, "+
            "{"+
              "\"original_height\": 6658, "+
              "\"sizes\": {"+
                "\"2000\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/12345.jpeg?size=2000\", "+
                "\"30\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/12345.jpeg?size=30\", "+
                "\"300\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/12345.jpeg?size=300\", "+
                "\"45\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/12345.jpeg?size=45\", "+
                "\"50\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/12345.jpeg?size=50\", "+
                "\"40\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/12345.jpeg?size=40\", "+
                "\"640\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/12345.jpeg?size=640\", "+
                "\"75\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/12345.jpeg?size=75\", "+
                "\"100\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/12345.jpeg?size=100\", "+
                "\"500\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/12345.jpeg?size=500\", "+
                "\"1000\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/12345.jpeg?size=1000\""+
              "}, "+
              "\"url\": \"https://dtvep25tfu0n1.cloudfront.net/media/i/product/12345.jpeg\", "+
              "\"created_at\": \"2014-09-22T20:23:04\", "+
              "\"modified_at\": \"2014-09-22T20:23:04\", "+
              "\"original_width\": 7848, "+
              "\"id\": \"hju7y\""+
            "}"+
          "], "+
          "\"id\": \"nnhTR5\", "+
          "\"categories\": ["+
            "{"+
              "\"title\": \"Cat1\", "+
              "\"created_at\": \"2013-03-23T13:36:35\", "+
              "\"modified_at\": null, "+
              "\"parent_id\": null, "+
              "\"product_count\": 15, "+
              "\"position\": 1, "+
              "\"id\": \"7yHU\""+
            "}, "+
            "{"+
              "\"title\": \"Cat2\", "+
              "\"created_at\": \"2013-09-23T13:43:33\", "+
              "\"modified_at\": null, "+
              "\"parent_id\": \"7yHU\", "+
              "\"product_count\": 9, "+
              "\"position\": 2, "+
              "\"id\": \"7yHI\""+
            "}"+
          "], "+
          "\"quantity\": null"+
        "}, "+
        "\"quantity\": 1"+
      "}"+
    "], "+
#endregion
    "\"created_at\": \"2014-12-13T12:22:54.879065\", " +
    "\"invoice_fee\": 0, "+
    "\"modified_at\": \"2014-12-23T12:22:12.461312\", " +
    "\"number\": 1234567, "+
    "\"note\": \"\", "+
    "\"currency\": \"SEK\", "+
    "\"shipping_alternative\": {"+
      "\"maximum_delivery_days\": 0, "+
      "\"regions\": ["+
        "\"SE\""+
      "], "+
      "\"description\": \"\", "+
      "\"free_at_price\": 2000000000, "+
      "\"created_at\": \"2013-10-22T22:52:53\", "+
      "\"title\": \"MailAgent\", " +
      "\"modified_at\": \"2014-03-13T13:37:03\", "+
      "\"price\": 100, "+
      "\"currency\": \"SEK\", "+
      "\"id\": \"k9l\", "+
      "\"minimum_delivery_days\": 0"+
    "}, "+
    "\"fullfilment\": {"+
      "\"status\": \"unhandled\", "+
      "\"price\": 98701, "+
      "\"provider\": null,"+ 
      "\"currency\": \"SEK\", "+
      "\"tracking_number\": null, "+
      "\"receiver\": {"+
        "\"city\": \"SmurfCity\", "+
        "\"name\": \"Cust mer\", "+
        "\"zip\": \"12 54\", "+
        "\"country\": \"SE\", "+
        "\"phone\": null, "+
        "\"state\": \"\", "+
        "\"street\": \"Sesamstreet 3\""+
      "}, "+
      "\"shipped_at\": null, "+
      "\"vat\": {"+
        "\"currency\": \"SEK\", "+
        "\"price\": 2340, "+
        "\"rate\": \"0.250000\""+
      "}"+
    "}, "+
    "\"price\": 998700, "+
    "\"id\": \"jUkM\", "+
    "\"vat\": {"+
      "\"currency\": \"SEK\", "+
      "\"price\": 73647, "+
      "\"rate\": \"0.250000\""+
    "}"+
  "}";
            #endregion Data
            var order = DeserializeGet(tictailJsonReponse);


            Assert.Equal("jUkM", order.Id);
            Assert.Equal(1234567, order.Number);
            Assert.Equal(998700, order.Price);
            Assert.Equal("SEK", order.Currency);
            Assert.Equal(0, order.InvoiceFee);
            Assert.Equal("", order.Note);
            Assert.Equal(true, order.PricesIncludeVat);
            DateTime createdAt = DateTime.Parse("2014-12-13T12:22:54.879065");
            Assert.Equal(createdAt, order.CreatedAt);
            DateTime modifiedAt = DateTime.Parse("2014-12-23T12:22:12.461312");
            Assert.Equal(modifiedAt, order.ModifiedAt);

            // Transaction
            Assert.NotNull(order.Transaction);
            Assert.Equal("paid", order.Transaction.Status);
            Assert.Equal("paypal", order.Transaction.Processor);
            Assert.Equal("2KY73837924000X", order.Transaction.Reference);
            Assert.Equal(new DateTime(2014, 9, 1, 14, 9, 8), order.Transaction.PaidAt);

            // Fullfillment
            Assert.NotNull(order.Fullfillment);
            Assert.Equal("unhandled", order.Fullfillment.Status);
            Assert.Equal(null, order.Fullfillment.TrackingNumber);
            Assert.Equal(null, order.Fullfillment.Provider);
            Assert.Equal(null, order.Fullfillment.ShippedAt);
            Assert.Equal(98701, order.Fullfillment.Price);
            Assert.Equal("SEK", order.Fullfillment.Currency);
            // Fullfillment -> Receiver
            Assert.NotNull(order.Fullfillment.Receiver);
            Assert.Equal("Cust mer", order.Fullfillment.Receiver.Name);
            Assert.Equal(null, order.Fullfillment.Receiver.Phone);
            Assert.Equal("Sesamstreet 3", order.Fullfillment.Receiver.Street);
            Assert.Equal("", order.Fullfillment.Receiver.State);
            Assert.Equal("SmurfCity", order.Fullfillment.Receiver.City);
            Assert.Equal("12 54", order.Fullfillment.Receiver.Zip);
            Assert.Equal("SE", order.Fullfillment.Receiver.Country);
            // Fullfillment -> Vat
            Assert.NotNull(order.Fullfillment.Vat);
            Assert.Equal(0.250000m, order.Fullfillment.Vat.Rate);
            Assert.Equal(2340, order.Fullfillment.Vat.Price);
            Assert.Equal("SEK", order.Fullfillment.Vat.Currency);

            // Customer
            Assert.NotNull(order.Customer);
            Assert.Equal("yUM", order.Customer.Id);
            Assert.Equal("cust.omer@gmail.com", order.Customer.Email);
            Assert.Equal("Cust omer", order.Customer.Name);
            Assert.Equal("SE", order.Customer.Country);
            Assert.Equal("en", order.Customer.Language);
            Assert.Equal(new DateTime(2013, 1, 18, 8, 3, 1), order.Customer.CreatedAt);
            Assert.Equal(null, order.Customer.ModifiedAt);
            //Vat
            Assert.NotNull(order.Vat);
            Assert.Equal(0.250000m, order.Vat.Rate);
            Assert.Equal(73647, order.Vat.Price);
            Assert.Equal("SEK", order.Vat.Currency);
            
            // Items
            Assert.NotNull(order.Items);
            Assert.Equal(1, order.Items.Count);
            // Items[0]
            Assert.Equal(52000, order.Items[0].Price);
            Assert.Equal("SEK", order.Items[0].Currency);
            Assert.Equal(1, order.Items[0].Quantity);
            // Items[0].Product
            Assert.Equal("nnhTR5", order.Items[0].Product.Id);
            Assert.Equal(null, order.Items[0].Product.Quantity);
            Assert.Equal(null, order.Items[0].Product.StoreUrl);
            Assert.Equal(null, order.Items[0].Product.StoreName);
            Assert.Equal("nh6", order.Items[0].Product.StoreId);
            Assert.Equal("Fanny Castelius - Sovshorts Ljusrosa", order.Items[0].Product.Title);
            Assert.Equal("Sovshorts&nbsp;smalrandiga sovshorts. Dekorativ spetskant \nnedtill, res\u00e5r i midjan samt ett band att knyta. Sovshortsen \u00e4r \ntillverkade i exklusivt Italiensk tyg av mycket god kvalitet. \nSovshortsen \u00e4r normala i storleken.<br><i><br>\"Fanny Castelius producerar eleganta och tidl\u00f6sa kl\u00e4desplagg med de mest kvalitativa av tyger f\u00f6r kvinnor som vill utstr\u00e5la sin inre elegans och sk\u00f6nhet. Fanny Castelius tror p\u00e5</i><i>&nbsp;p\u00e5 att denna kvinna alltid \u00e4r en sk\u00f6nhet, b\u00e5de i fram och i motg\u00e5ng.\"</i><br><br>", order.Items[0].Product.Description);
            Assert.Equal("published", order.Items[0].Product.Status);
            Assert.Equal((uint)74100, order.Items[0].Product.Price);
            Assert.Equal("SEK", order.Items[0].Product.Currency);
            Assert.Equal("fanny-castelius-sovshorts-ljusrosa", order.Items[0].Product.Slug);
            Assert.Equal(true, order.Items[0].Product.Unlimited);
            Assert.Equal(new DateTime(2014, 8, 11, 21, 12, 14), order.Items[0].Product.CreatedAt);
            Assert.Equal(new DateTime(2014, 9, 9, 4, 2, 18), order.Items[0].Product.ModifiedAt);
            // Items[0].Product.Categories
            Assert.NotNull(order.Items[0].Product.Categories);
            Assert.Equal(2, order.Items[0].Product.Categories.Count);
            // Items[0].Product.Categories[0]
            Assert.Equal("7yHU", order.Items[0].Product.Categories[0].Id);
            Assert.Equal("Cat1", order.Items[0].Product.Categories[0].Title);
            Assert.Equal(15, order.Items[0].Product.Categories[0].ProductCount);
            Assert.Equal(1, order.Items[0].Product.Categories[0].Position);
            Assert.Equal(null, order.Items[0].Product.Categories[0].ParentId);
            Assert.Equal(new DateTime(2013, 3, 23, 13, 36, 35), order.Items[0].Product.Categories[0].CreatedAt);
            Assert.Equal(null, order.Items[0].Product.Categories[0].ModifiedAt);
            // Items[0].Product.Categories[1]
            Assert.Equal("7yHI", order.Items[0].Product.Categories[1].Id);
            Assert.Equal("Cat2", order.Items[0].Product.Categories[1].Title);
            Assert.Equal(9, order.Items[0].Product.Categories[1].ProductCount);
            Assert.Equal(2, order.Items[0].Product.Categories[1].Position);
            Assert.Equal("7yHU", order.Items[0].Product.Categories[1].ParentId);
            Assert.Equal(new DateTime(2013, 9, 23, 13, 43, 33), order.Items[0].Product.Categories[1].CreatedAt);
            Assert.Equal(null, order.Items[0].Product.Categories[1].ModifiedAt);
            //Items[0].Product.Variation
            Assert.NotNull(order.Items[0].Product.Variation);
            Assert.Equal("KUyy", order.Items[0].Product.Variation.Id);
            Assert.Equal("36", order.Items[0].Product.Variation.Title);
            Assert.Equal(null, order.Items[0].Product.Variation.Quantity);
            Assert.Equal(new DateTime(2014,9,9,10,20,40), order.Items[0].Product.Variation.ModifiedAt);
            Assert.Equal(new DateTime(2011,1,20,22,13,55), order.Items[0].Product.Variation.CreatedAt);
            Assert.Equal(true, order.Items[0].Product.Variation.Unlimited);
            //Items[0].Product.Images
            Assert.Equal(3, order.Items[0].Product.Images.Count);
            Assert.Equal("ki9u", order.Items[0].Product.Images[0].Id);
            Assert.Equal("kli9u", order.Items[0].Product.Images[1].Id);
            Assert.Equal("hju7y", order.Items[0].Product.Images[2].Id);

            // Discounts
            Assert.NotNull(order.Discounts);
            Assert.Equal(1, order.Discounts.Count);
            Assert.Equal("6yt", order.Discounts[0].Id);
            Assert.Equal("Discout name", order.Discounts[0].Title);
            Assert.Equal("published", order.Discounts[0].Status);
            Assert.Equal("money_off", order.Discounts[0].Type);
            Assert.Equal(100, order.Discounts[0].Amount);
            Assert.Equal(0, order.Discounts[0].MinimumPrice);
            Assert.Equal(true, order.Discounts[0].Storewide);
            //Assert.Equal("all", order.Discounts[0].ApplicableTo); // TODO
            Assert.Equal(new DateTime(2014, 7, 2, 2, 15, 35), order.Discounts[0].CreatedAt);
            Assert.Equal(new DateTime(2014, 8, 2, 10, 24, 45), order.Discounts[0].ModifiedAt);
            Assert.Equal("SEK", order.Discounts[0].Currency);

            // Shipping alternative
            Assert.NotNull(order.ShippingAlternative);
            Assert.Equal("k9l", order.ShippingAlternative.Id);
            Assert.Equal("MailAgent", order.ShippingAlternative.Title);
            Assert.Equal("", order.ShippingAlternative.Description);
            Assert.Equal(2000000000, order.ShippingAlternative.FreeAtPrice);
            Assert.Equal(100, order.ShippingAlternative.Price);
            Assert.Equal("SEK", order.ShippingAlternative.Currency);
            Assert.Equal(0, order.ShippingAlternative.MinimumDeliveryDays);
            Assert.Equal(0, order.ShippingAlternative.MaximumDeliveryDays);
            Assert.Equal(1, order.ShippingAlternative.Regions.Count);
            Assert.Contains("SE", order.ShippingAlternative.Regions);
            Assert.Equal(new DateTime(2013, 10, 22, 22, 52, 53), order.ShippingAlternative.CreatedAt);
            Assert.Equal(new DateTime(2014, 3, 13, 13, 37, 3), order.ShippingAlternative.ModifiedAt);
        }
             

        [Fact]
        public void DeserializeGet_Ok_Order()
        {

            #region data
            const string tictailJsonReponse =
            "{" +
                "\"id\":\"123abc\"," +
                "\"number\":34," +
                "\"price\":12345," +
                "\"currency\":\"SEK\"," +
                "\"invoice_fee\":3," +
                "\"note\":\"A nice order\"," +
                "\"prices_include_vat\":true," +
                "\"transaction\":" +
                "{" +
                "\"status\":\"paid\"," +
                "\"processor\":\"visa\"," +
                "\"reference\":\"xyz123\"," +
                "\"paid_at\":\"2014-01-23T11:12:13\"" +
                "}," +
                "\"fullfilment\":" +
                "{" +
                    "\"status\":\"shipped\"," +
                    "\"receiver\":" +
                    "{" +
                        "\"name\":\"Some Receiver\"," +
                        "\"phone\":\"+11 123456\"," +
                        "\"street\":\"My street1\"," +
                        "\"state\":\"My state1\"," +
                        "\"city\":\"My city1\"," +
                        "\"zip\":\"z1234\"," +
                        "\"country\":\"MyCountry\"" +
                    "}," +
                    "\"tracking_number\":\"wsx123\"," +
                    "\"provider\":\"post\"," +
                    "\"shipped_at\":\"2014-02-24T12:13:15\"," +
                    "\"price\":\"2054\"," +
                    "\"currency\":\"SEK\"," +
                    "\"vat\":" +
                    "{" +
                        "\"rate\":3," +
                        "\"price\":\"1223\"," +
                        "\"currency\":\"SEK\"" +
                    "}," +
                "}," +
                "\"customer\":" +
                "{" +
                    "\"id\":\"c123\"," +
                    "\"email\":\"some1@email.com\"," +
                    "\"name\":\"My Name\"," +
                    "\"country\":\"Sweden\"," +
                    "\"language\":\"Swedish\"," +
                    "\"created_at\":\"2014-03-25T13:14:16\"," +
                    "\"modified_at\":\"2014-04-26T14:15:17\"" +
                "}," +
                "\"vat\":" +
                "{" +
                    "\"rate\":5," +
                    "\"price\":3445," +
                    "\"currency\":\"SEK\"" +
                "}," +
                "\"items\":" +
                "[" +
                    "{" +
                        "\"price\":3498," +
                        "\"currency\":\"SEK\"," +
                        "\"quantity\":3," +
                        "\"product\":" +
                         "{" +
                              "\"id\": \"nmo23\"," +
                              "\"status\": \"published\", " +
                              "\"description\": \"Nice product<br>\", " +
                              "\"title\": \"Product1\", " +
                              "\"store_id\": \"ab1\", " +
                              "\"unlimited\": false, " +
                              "\"created_at\": \"2014-08-13T22:11:23\", " +
                              "\"modified_at\": \"2014-09-14T20:02:11\", " +
                              "\"slug\": \"prod1\", " +
                              "\"price\": 25000, " +
                              "\"currency\": \"SEK\"" +
                          "}" +
                    "}," +
                    "{" +
                        "\"price\":9845," +
                        "\"currency\":\"EUR\"," +
                        "\"quantity\":4," +
                        "\"product\":" +
                        "{" +
                              "\"id\": \"prq12\"," +
                              "\"status\": \"unpublished\", " +
                              "\"description\": \"Other Nice product<br>\", " +
                              "\"title\": \"Product2\", " +
                              "\"store_id\": \"ab2\", " +
                              "\"unlimited\": true, " +
                              "\"created_at\": \"2014-10-20T12:13:43\", " +
                              "\"modified_at\": \"2014-11-21T21:02:41\", " +
                              "\"slug\": \"prod2\", " +
                              "\"price\": 24600, " +
                              "\"currency\": \"EUR\"" +
                          "}" +
                    "}" +
                "]," +
                "\"discounts\":" +
                "[" +
                    "{" +
                        "\"id\":\"d123\"," +
                        "\"title\":\"Discount1\"," +
                        "\"status\":\"published\"," +
                        "\"type\":\"money_off\"," +
                        "\"amount\":12367," +
                        "\"minimum_price\":7654," +
                        "\"storewide\":true," +
                        "\"applicable_to\":\"all\"," +
                        "\"created_at\":\"2014-05-12T21:22:23\"," +
                        "\"modified_at\":\"2014-06-13T22:23:24\"," +
                        "\"currency\":\"SEK\"" +
                  "}" +
                "]," +
                "\"shipping_alternative\":" +
                "{" +
                    "\"id\":\"sa123\"," +
                    "\"title\":\"Shipping1\"," +
                    "\"description\":\"Description1\"," +
                    "\"free_at_price\":134," +
                    "\"price\":5647," +
                    "\"currency\":\"SEK\"," +
                    "\"minimum_delivery_days\":2," +
                    "\"maximum_delivery_days\":8," +
                    "\"regions\":[\"SE\",\"EN\"]," +
                    "\"created_at\":\"2014-06-18T21:11:23\"," +
                    "\"modified_at\":\"2014-06-19T22:21:33\"," +
                "}," +
                "\"created_at\":\"2013-06-24T20:01:02\"," +
                "\"modified_at\":\"2014-12-24T21:10:20\"" +
            "}";

#endregion
            var order = DeserializeGet(tictailJsonReponse);

            Assert.Equal("123abc", order.Id);
            Assert.Equal(34, order.Number);
            Assert.Equal(12345, order.Price);
            Assert.Equal("SEK", order.Currency);
            Assert.Equal(3, order.InvoiceFee);
            Assert.Equal("A nice order", order.Note);
            Assert.Equal(true, order.PricesIncludeVat);
            Assert.Equal(new DateTime(2013, 6, 24, 20, 1, 2), order.CreatedAt);
            Assert.Equal(new DateTime(2014, 12, 24, 21, 10, 20), order.ModifiedAt);
                        
            // Transaction
            Assert.NotNull(order.Transaction);
            Assert.Equal("paid", order.Transaction.Status);
            Assert.Equal("visa", order.Transaction.Processor);
            Assert.Equal("xyz123", order.Transaction.Reference);
            Assert.Equal(new DateTime(2014,1,23,11,12,13), order.Transaction.PaidAt);
            // Fullfillment
            Assert.NotNull(order.Fullfillment);          
            Assert.Equal("shipped", order.Fullfillment.Status);
            Assert.Equal("wsx123", order.Fullfillment.TrackingNumber);
            Assert.Equal("post", order.Fullfillment.Provider);
            Assert.Equal(new DateTime(2014,2,24,12,13,15), order.Fullfillment.ShippedAt);
            Assert.Equal(2054, order.Fullfillment.Price);
            Assert.Equal("SEK", order.Fullfillment.Currency);
            Assert.Equal("shipped", order.Fullfillment.Status);
                        
            // Fullfillment -> Receiver
            Assert.NotNull(order.Fullfillment.Receiver);
            Assert.Equal("Some Receiver", order.Fullfillment.Receiver.Name);
            Assert.Equal("+11 123456", order.Fullfillment.Receiver.Phone);
            Assert.Equal("My street1", order.Fullfillment.Receiver.Street);
            Assert.Equal("My state1", order.Fullfillment.Receiver.State);
            Assert.Equal("My city1", order.Fullfillment.Receiver.City);
            Assert.Equal("z1234", order.Fullfillment.Receiver.Zip);
            Assert.Equal("MyCountry", order.Fullfillment.Receiver.Country);
            // Fullfillment -> Vat
            Assert.NotNull(order.Fullfillment.Vat);
            Assert.Equal(3, order.Fullfillment.Vat.Rate);
            Assert.Equal(1223, order.Fullfillment.Vat.Price);
            Assert.Equal("SEK", order.Fullfillment.Vat.Currency);
                       
            // Customer
            Assert.NotNull(order.Customer);
            Assert.Equal("c123", order.Customer.Id);
            Assert.Equal("some1@email.com", order.Customer.Email);
            Assert.Equal("My Name", order.Customer.Name);
            Assert.Equal("Sweden", order.Customer.Country);
            Assert.Equal("Swedish", order.Customer.Language);
            Assert.Equal(new DateTime(2014,3,25,13,14,16), order.Customer.CreatedAt);
            Assert.Equal(new DateTime(2014,4,26,14,15,17), order.Customer.ModifiedAt);
            Assert.NotNull(order.Vat);
            Assert.Equal(5, order.Vat.Rate);
            Assert.Equal(3445, order.Vat.Price);
            Assert.Equal("SEK", order.Vat.Currency);

                        // Items
            Assert.NotNull(order.Items);
            Assert.Equal(2, order.Items.Count);
            // Items[0]
            Assert.Equal(3498,order.Items[0].Price);
            Assert.Equal("SEK", order.Items[0].Currency);
            Assert.Equal(3, order.Items[0].Quantity);

            Assert.Equal("nmo23", order.Items[0].Product.Id);
            Assert.Equal("Product1", order.Items[0].Product.Title);
            Assert.Equal("Nice product<br>", order.Items[0].Product.Description);
            Assert.Equal("published", order.Items[0].Product.Status);
            Assert.Equal((uint)25000, order.Items[0].Product.Price);
            Assert.Equal("SEK", order.Items[0].Product.Currency);
            Assert.Equal("prod1", order.Items[0].Product.Slug);
            Assert.Equal(false, order.Items[0].Product.Unlimited);
            Assert.Equal(new DateTime(2014, 8, 13, 22, 11, 23), order.Items[0].Product.CreatedAt);
            Assert.Equal(new DateTime(2014, 9, 14, 20, 2, 11), order.Items[0].Product.ModifiedAt);

            // Items[1]
            Assert.Equal(9845, order.Items[1].Price);
            Assert.Equal("EUR", order.Items[1].Currency);
            Assert.Equal(4, order.Items[1].Quantity);

            Assert.Equal("prq12", order.Items[1].Product.Id);
            Assert.Equal("Product2", order.Items[1].Product.Title);
            Assert.Equal("Other Nice product<br>", order.Items[1].Product.Description);
            Assert.Equal("unpublished", order.Items[1].Product.Status);
            Assert.Equal((uint)24600, order.Items[1].Product.Price);
            Assert.Equal("EUR", order.Items[1].Product.Currency);
            Assert.Equal("prod2", order.Items[1].Product.Slug);
            Assert.Equal(true, order.Items[1].Product.Unlimited);
            Assert.Equal(new DateTime(2014, 10, 20, 12, 13, 43), order.Items[1].Product.CreatedAt);
            Assert.Equal(new DateTime(2014, 11, 21, 21, 2, 41), order.Items[1].Product.ModifiedAt);

            // Discounts
            Assert.NotNull(order.Discounts);
            Assert.Equal(1, order.Discounts.Count);
            Assert.Equal("d123", order.Discounts[0].Id);
            Assert.Equal("Discount1", order.Discounts[0].Title);
            Assert.Equal("published", order.Discounts[0].Status);
            Assert.Equal("money_off", order.Discounts[0].Type);
            Assert.Equal(7654, order.Discounts[0].MinimumPrice);
            Assert.Equal(true, order.Discounts[0].Storewide);
            //Assert.Equal("all", order.Discounts[0].ApplicableTo);
            Assert.Equal(new DateTime(2014,5,12,21,22,23), order.Discounts[0].CreatedAt);
            Assert.Equal(new DateTime(2014,6,13,22,23,24), order.Discounts[0].ModifiedAt);
            Assert.Equal("SEK", order.Discounts[0].Currency);
            // Shipping alternative
            Assert.NotNull(order.ShippingAlternative);
            Assert.Equal("sa123", order.ShippingAlternative.Id);
            Assert.Equal("Shipping1", order.ShippingAlternative.Title);
            Assert.Equal("Description1", order.ShippingAlternative.Description);
            Assert.Equal(134, order.ShippingAlternative.FreeAtPrice);
            Assert.Equal(5647, order.ShippingAlternative.Price);
            Assert.Equal("SEK", order.ShippingAlternative.Currency);
            Assert.Equal(2, order.ShippingAlternative.MinimumDeliveryDays);
            Assert.Equal(8, order.ShippingAlternative.MaximumDeliveryDays);
            Assert.Equal(2, order.ShippingAlternative.Regions.Count);
            Assert.Contains("SE", order.ShippingAlternative.Regions);
            Assert.Contains("EN", order.ShippingAlternative.Regions);
            Assert.Equal(new DateTime(2014,6,18,21,11,23), order.ShippingAlternative.CreatedAt);
            Assert.Equal(new DateTime(2014,6,19,22,21,33), order.ShippingAlternative.ModifiedAt);
                         
        }

        [Fact]
        public void DeserializeRangeGet_Ok_Order()
        {
            const string tictailJsonReponse =
                "[" + "{" +
                "\"id\":\"123abc\"," +
                "},"+
            "{" +
                "\"id\":\"bcd123\"," +
            "}" +
                "]";

            var ordersResponse = DeserializeRangeGet(tictailJsonReponse);
            var orders = Cast<Order>(ordersResponse).ToList();
            Assert.Equal(2, orders.Count);
            Assert.Equal("123abc", orders[0].Id);
            Assert.Equal("bcd123", orders[1].Id);
        }

        #endregion

        IEnumerable<T> Cast<T>(IEnumerator iterator)
        {
            while (iterator.MoveNext())
            {
                yield return (T)iterator.Current;
            }
        }

    }
}

