import React, { SyntheticEvent } from 'react'
import CardOffer from './CardOffer';
import { Offer } from '../../../product'

interface Props {
    offersResult: Offer[] | null;
    onOfferCreate: (e: SyntheticEvent) => void;
}

const ListOffer: React.FC<Props> = ({ offersResult, onOfferCreate }) => {
  if (!offersResult || !Array.isArray(offersResult) || offersResult.length === 0) {
    return (
      <div className="flex items-center justify-center min-h-screen">
        <p className="text-xl font-semibold text-gray-600 text-center">
          No offer found
        </p>
      </div>
    );
  }
  
  return (
    <div className="grid grid-cols-1 gap-4 md:grid-cols-2 lg:grid-cols-3">
      {offersResult.map((offer) => (
        <CardOffer
          id={offer.offerId} // Assuming `offerId` exists in the `Offer` type
          key={offer.offerId} // Fixed: Correct key usage
          offerResult={offer}
          onOfferCreate={onOfferCreate}
        />
      ))}
    </div>
  );
};

export default ListOffer;
