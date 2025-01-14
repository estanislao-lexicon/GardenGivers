import React, { SyntheticEvent } from 'react'
import DeleteOffer from './DeleteOffer';
import { Link } from 'react-router-dom';

interface Props {
    offerCreated: string;
    onOfferDelete: (e:SyntheticEvent) => void;
}

const CardOffer = ({offerCreated, onOfferDelete}: Props) => {
  return (           
    <div className="flex flex-col w-full p-8 space-y-4 text-center rounded-lg shadow-lg md:w-1/3">
      <Link to={`offer/${offerCreated}`} className="pt-6 text-xl font-bold">{offerCreated}</Link>
      <DeleteOffer 
        onOfferDelete={onOfferDelete} 
        offerCreated={offerCreated} 
      />
    </div>    
  )
}

export default CardOffer;