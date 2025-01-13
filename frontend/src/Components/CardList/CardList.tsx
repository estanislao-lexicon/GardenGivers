import { JSX, SyntheticEvent } from 'react'
import Card from '../Card/Card'
import { ProductSearch } from '../../product'


interface Props {
  searchResult: ProductSearch | null;
  onOfferCreate: (e: SyntheticEvent) => void;
}

const CardList: React.FC<Props> = ({ searchResult, onOfferCreate }: Props) : JSX.Element => {
  console.log('Props received in CardList:', {searchResult});
  console.log('searchResult from CardList:', searchResult?.productName);

  if (!searchResult) {
    return <p>No results found</p>;
  }

  return (
    <div>     
      <Card 
        id={searchResult.productId.toString()} 
        key={searchResult?.productId} 
        searchResult={searchResult}
        onOfferCreate={onOfferCreate}
      />   
    </div>  
  );
};

export default CardList;
