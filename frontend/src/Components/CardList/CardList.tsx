import { JSX, SyntheticEvent } from 'react'
import Card from '../Card/Card'
import { ProductSearch } from '../../product'


interface Props {
  searchResult: ProductSearch | null;
  onOfferCreate: (e: SyntheticEvent) => void;
}

const CardList: React.FC<Props> = ({ searchResult, onOfferCreate }: Props) : JSX.Element => {  
  
  if (!searchResult || !Array.isArray(searchResult) || searchResult.length === 0) {
    return <p>No results found</p>;
  }

  return (
    <div>
      {searchResult.length > 0 ? (
        searchResult.map((product) => (
          <Card 
            id={product.productId.toString()} 
            key={product.productId} 
            searchResult={product}
            onOfferCreate={onOfferCreate}
          />
        ))
      ) : (
        <p className="mb-3 mt-3 text-xl font-semibold text-gray-600 text-center md:text-xl">
          No results found
        </p>
      )}
    </div>
  );
};

export default CardList;
