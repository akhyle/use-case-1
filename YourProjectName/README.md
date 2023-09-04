# UseCase

UseCase is a complete solution for all country enthusiasts. 

## Local installation
Download application files from the GitHub repository.
Build solutions using CLI or VisualStudio.

## Usage

```csharp
[HttpGet("get-paginated-list")]
public async Task<IActionResult> GetPaginatedList( [FromQuery] string? countryName, int? populationInMillions, string? sortDirection, int? take)
{
    var countries = await _countryHandler.GetCountryList(countryName, populationInMillions, sortDirection, take);

    return Ok(countries);
}
```
There are *4* query parameters to be provided
countryName - null or string value - allows filtering the resulting list by country name. Ignores case.

populationInMillions - null or integer - allows filtering the resulting list by population size.
All results with a population greater or equal to the provided are filtered out.

sortDirection - null or string - determines order direction. Available values are Descend and Ascend

take - null or integer - determines how many values to fetch from the start of the sequence. If omitted, all the available items are returned.

## Use examples

```
Uri: /Public/get-paginated-list
Result: all available countries

Uri: /Public/get-paginated-list?countryName=Fr
Result: all available countries that include 'Fr' in the name

Uri: /Public/get-paginated-list?populationInMillions=10
Result: all available countries that have a population of less than 10 million people

Uri: /Public/get-paginated-list?sortDirection=Ascend
Result: all available countries sorted by name in ascending order

Uri: /Public/get-paginated-list?take=15
Result: 15 available countries from the start of the list

Uri: /Public/get-paginated-list?countryName=ger&populationInMillions=5
Result: only countries that include 'ger' in the name and have a population of less than 5 million

Uri: /Public/get-paginated-list?countryName=ger&populationInMillions=5&sortDirection=Descend
Result: only countries that include 'ger' in the name and have a population of less than 5 million are sorted in descending order

Uri: /Public/get-paginated-list?countryName=ger&populationInMillions=5&sortDirection=Descend&take=5
Result: first 5 countries that include 'ger' in the name and have a population of less than 5 million are sorted in descending order

Uri: /Public/get-paginated-list?sortDirection=Descend&take=5
Result: 5 entries from the end of the list

Uri: /Public/get-paginated-list?sortDirection=Ascend&take=5
Result: 5 entries from the start of the list
```
