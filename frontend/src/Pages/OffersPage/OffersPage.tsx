import React, { useState } from 'react'
import ListsOffers from '../../Components/Interactions/Offer/ListOffers';

interface Props {}

const OffersPage = (props: Props) => {
  const [offersCreated, setOffersCreated] = useState<string[]>([]);

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
  
  return (
    <div>
    <ListsOffers offersCreated={offersCreated} onOfferDelete={onOfferDelete} />
    </div>
  )
};

export default OffersPage;
