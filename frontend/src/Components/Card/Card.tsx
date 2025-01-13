import { JSX, SyntheticEvent } from 'react'
import "./Card.css";
import { ProductSearch } from '../../product';
import Offer from '../Interactions/Offer';

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
    <div key={id} id={id} className='card'>        
        <div className='details'>          
            <h2>{searchResult.productName}</h2>
            <p className='info'>Description: {searchResult.productDescription}</p>
            <p>{id}</p>
            <Offer 
              onOfferCreate={onOfferCreate}
              />
        </div>
    </div>
  )
}

export default Card;