import React, { SyntheticEvent, useState } from 'react'
import Navbar from '../../Components/NavBar/Navbar';
import Hero from '../../Components/Hero/Hero';
import Search from '../../Components/Search/Search';
import ListOffer from '../../Components/Interactions/Offer/ListOffers';
import CardList from '../../Components/CardList/CardList';
import { ProductSearch, searchProductByName } from '../../api';


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

  const onOfferDelete = (e: any) => {
    e.preventDefault();
    const removedOffer = offersCreated.filter((offer) => {
      return offer !== e.target[0].value;
    });
    setOffersCreated(removedOffer);
  };

  const onSearchSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    setServerError(null);

    const result = await searchProductByName(search);
    console.log('Result in APP:', result);
        
    if (typeof result === 'string') {
      setServerError(result);
    } else if (result) {
      setSearchResult(result);  // Wrap result in an array
    }
  };
  
  return (
    <div className="App">
      <Search onSearchSubmit={onSearchSubmit} search={search} handleSearchChange={handleSearchChange}/>
      <ListOffer offersCreated={offersCreated} onOfferDelete={onOfferDelete} />
      <CardList searchResult={searchResult} onOfferCreate={onOfferCreate}/>
      {serverError && <p>{serverError}</p>}
    </div>
  )
};

export default SearchPage;
