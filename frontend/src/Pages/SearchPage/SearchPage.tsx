import React, { SyntheticEvent, useState } from 'react'
import Search from '../../Components/Search/Search';
import CardList from '../../Components/Interactions/Product/ListProducts';
import { searchProductByName } from '../../api';
import { ProductSearch } from '../../product';


interface Props {}

const SearchPage = (props: Props) => {
  const [search, setSearch] = useState<string>("");
  const [offersCreated, setOffersCreated] = useState<string[]>([]);
  const [searchResult, setSearchResult] = useState<ProductSearch | null>(null);
  const [serverError, setServerError] = useState<string | null>(null);

  const handleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value);    
  };

  const onOfferCreate = (e: any) => {
    e.preventDefault();
    const exists = offersCreated.find((offer) => offer === e.target[0].value);
    if (exists) {
      return;
    }
    const updatedOfferList = [...offersCreated, e.target[0].value];
    setOffersCreated(updatedOfferList);
  };
  
  const onSearchSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    if (!search.trim()) {
      setSearchResult(null);
      return;
    }
    setServerError(null);

    const result = await searchProductByName(search);
            
    if (typeof result === 'string') {
      setServerError(result);
    } else if (result) {
      setSearchResult(result);  // Wrap result in an array
    }
  };
  
  return (
    <div className="App">
      <Search onSearchSubmit={onSearchSubmit} search={search} handleSearchChange={handleSearchChange}/>      
      <CardList searchResult={searchResult} onOfferCreate={onOfferCreate}/>
      {serverError && <p>{serverError}</p>}
    </div>
  )
};

export default SearchPage;
