import React, { SyntheticEvent } from 'react'
import CardOffer from './CardOffer';

interface Props {
    offersCreated: string[];
    onOfferDelete: (e: SyntheticEvent) => void;
}

const ListOffer = ({ offersCreated, onOfferDelete }: Props) => {
  return (
    <section id="offers-created">
      <h2 className="mb-3 mt-3 text-3xl font-semibold text-center md:text-4xl">
        Offers Created
      </h2>
      <div className="relative flex flex-col items-center max-w-5xl mx-auto space-y-10 px-10 mb-5 md:px-6 md:space-y-0 md:space-x-7 md:flex-row">
        {offersCreated && offersCreated.length > 0 ? (
          offersCreated.map((offerCreated) => (
            <CardOffer 
              // key={offerCreated.id} 
              offerCreated={offerCreated} 
              onOfferDelete={onOfferDelete}
            />
          ))
        ) : (
          <h3 className="mb-3 mt-3 text-xl font-semibold text-center md:text-xl">
            No Offers created.
          </h3>
        )}
      </div>      
    </section>
  );
};

export default ListOffer;
