using RestSharp;

/*
var client = new RestClient("https://api.collectapi.com/imdb/imdbSearchById?movieId=tt1375666");
var request = new RestRequest("https://api.collectapi.com/imdb/imdbSearchById?movieId=tt1375666", Method.Get);
request.AddHeader("authorization", "apikey 60tdNjiQDmSkDWyzRy0Jq0:01SZtp19rrUo2H3bnxcuIj");
request.AddHeader("content-type", "application/json");
RestResponse response = client.Execute(request);

Console.WriteLine(response.Content);

*/

var client = new RestClient("https://api.collectapi.com/health/dutyPharmacy?ilce=%C3%87ankaya&il=Ankara");
var request = new RestRequest("https://api.collectapi.com/health/dutyPharmacy?ilce=%C3%87ankaya&il=Ankara", Method.Get);
request.AddHeader("authorization", "apikey 60tdNjiQDmSkDWyzRy0Jq0:01SZtp19rrUo2H3bnxcuIj");
request.AddHeader("content-type", "application/json");
RestResponse response = client.Execute(request);

Console.WriteLine(response.Content);



