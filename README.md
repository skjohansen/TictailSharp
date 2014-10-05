This is an unofficial OpenSource .NET-implementation of the [Tictail API](https://tictail.com/developers/documentation/api-reference/), available under MIT License.  

This is implemented to work against the Tictail API using an API-Key, which can be obtained through the API test app (in Tictail, you need to open an developer account).

How to use (C#)
    
    var endpoint = new TictailEndpoint(new Uri("https://api.tictail.com"), "accesstoken_[YOUR_API_KEY]");
    var repository = new TictailRepository(endpoint);
    var me = repository.Me.Get();
    Console.WriteLine(me.Name); // Outputs the storename
	Console.WriteLine(me.Id); // Outputs the Tictail ID of your store

List all orders (C#)
					
	var storeId = me.Id;
    var myStore = repository.Stores[storeId];
	foreach (var order in store.Orders)
    {
        Console.WriteLine(order.CreatedAt.ToString());
    }


Not yet implemented (2014-10-05):

* Card
* In-App Purchase

