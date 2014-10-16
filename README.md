This is an unofficial OpenSource .NET-implementation of the [Tictail API](https://tictail.com/developers/documentation/api-reference/), available under MIT License.  

[Download via NuGet](https://www.nuget.org/packages/TictailSharp/)

What is this?
===
[Tictail](http://tictail.com) is an easy to use SaaS ecommerce platform, which is (currently) free of charge.

In Tictail have the users (shop owners) the possibility to add app to their store, these apps can both be free and cost money, and this is up to the developer.

You can use this API when creating the server-side of Tictail apps, or use it to extract data from your own Tictail store. From the API is it possible to access most information within a Tictail store, sadly it do not give much write access (yet).

Getting started
===
To make requests using the Tictail API, you will need an access-token.<br />
When testing the easiest way to obtain an access-token is through the "Tictail API Explorer"-app (you need to open a developer account to find this in the app-store).<br />
However, the correct way to obtain an access-token when developing external apps is to use the [Tictail OAuth](https://tictail.com/developers/documentation/authentication/) to trade the authorization-code for an access-token.

Obtain your access token using OAuth (C#):

    var endpointAuth = new TictailEndpoint(new Uri("https://tictail.com"));
    var repositoryAuth = new TictailRepository(endpointAuth);
    var oauth = new Oauth()
    {
        AuthCode = "CODE", // eg. authcode_abcdefgh1234 (from app)
        ClientId = "YOUR_CLIENT_ID", //eg. clientid_12345ABCDEFGH (see app-credentials)
        ClientSecret = "YOUR_CLIENT_SECRET" // eg. clientsecret_asdf123 (see app-credentials)
    };

    var token = repositoryAuth.Oauth.Post(oauth);

Example on how to fetch "who am I"-information (C#), uses the token from above:
    
    var endpoint = new TictailEndpoint(new Uri("https://api.tictail.com"), token.AccessToken);
    var repository = new TictailRepository(endpoint);
    var me = repository.Me.Get();
    Console.WriteLine(me.Name); // Outputs the storename
	Console.WriteLine(me.Id); // Outputs the Tictail ID of your store

List all orders (C#) this example uses the repository above:
					
	var storeId = me.Id;
    var myStore = repository.Stores[storeId];
	foreach (var order in store.Orders)
    {
        Console.WriteLine(order.CreatedAt.ToString());
    }


Not yet implemented (2014-10-15):

* Card
* In-App Purchase