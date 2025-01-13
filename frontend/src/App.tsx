import { SyntheticEvent, useState } from 'react';
import './App.css';
import CardList from './Components/CardList/CardList';
import Search from './Components/Search/Search';
import { ProductSearch } from './product';
import { searchProductById } from './api';

function App() {
  const [search, setSearch] = useState<string>("");
  const [searchResult, setSearchResult] = useState<ProductSearch | null>(null);
  const [serverError, setServerError] = useState<string | null>(null);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value);    
  };

  const onOfferCreate = async (e: SyntheticEvent) => {
    e.preventDefault();
    console.log("Offer Created");
  };

  const onClick = async (e: SyntheticEvent) => {
    e.preventDefault();
    setServerError(null);

    const result = await searchProductById(search);
    console.log('Result in APP:', result);
        
    if (typeof result === 'string') {
      setServerError(result);
    } else if (result) {
      setSearchResult(result);  // Wrap result in an array
    }
  };

  return (
    <div className="App">
      <Search onClick={onClick} search={search} handleChange={handleChange}/>      
      <CardList searchResult={searchResult} onOfferCreate={onOfferCreate}/>
      {serverError && <p>{serverError}</p>}
    </div>
  );
}

export default App;