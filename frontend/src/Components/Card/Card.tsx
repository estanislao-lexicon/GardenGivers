import { JSX, SyntheticEvent } from 'react'
import "./Card.css";
import { ProductSearch } from '../../product';
import AddOffer from '../Interactions/Offer/AddOffer';

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
    <div 
      className="flex flex-col items-center justify-between w-full p-6 bg-slate-100 rounded-lg md:flex-row"
      key={id} 
      id={id} 
    >        
      <h2 className='font-bold text-center text-black md:text-left'>
        {searchResult.productName}
      </h2>
      <p className="text-black">Description: {searchResult.productDescription}</p>            
      <AddOffer 
        onOfferCreate={onOfferCreate}
        productId={searchResult.productId}
        productName={searchResult.productName}              
      />      
    </div>
  )
}

export default Card;