import { JSX, SyntheticEvent } from 'react'
import { ProductSearch } from '../../../product';
import AddOffer from '../Offer/AddOffer';
import { Link } from 'react-router-dom';

interface Props {
  id: string;
  searchResult: ProductSearch;
  onOfferCreate: (e: SyntheticEvent) => void;
}

const Card: React.FC<Props> = ({ 
  id, 
  searchResult,
  onOfferCreate,
}: Props) : JSX.Element => {
  
  return (
    <div className="text-sm leading-6 mb-5">
      <figure className="flex flex-col-reverse items-center justify-center bg-slate-100 rounded-xl p-6 max-w-md mx-auto">
        <blockquote className="mt-6 text-slate-700 text-center">
          <p>{searchResult.productDescription}</p>
        </blockquote>
        <figcaption className="flex items-center space-x-4">
              
          <Link to={`/product/${searchResult.productName}`} className="text-base text-slate-900 font-semibold">
            {searchResult.productName}
          </Link>            
          <AddOffer
            onOfferCreate={onOfferCreate}
            productId={searchResult.productId}
            productName={searchResult.productName}
          />               
        </figcaption>
      </figure>
    </div>
  )
}

export default Card;