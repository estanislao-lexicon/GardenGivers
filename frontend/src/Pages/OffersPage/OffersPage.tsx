import React, { SyntheticEvent, useEffect, useState } from 'react'
import ListOffers from '../../Components/Interactions/Offer/ListOffers';
import { getAllOffers } from '../../api';
import { Offer } from '../../product';

interface Props {}

const OffersPage = (props: Props) => {
  const [offersCreated, setOffersCreated] = useState<string[]>([]);
  const [offersResult, setOffersResult] = useState<Offer[]>([]);
  const [serverError, setServerError] = useState<string | null>(null);


  // Fetch all offers when the component mounts
  useEffect(() => {
    const fetchOffers = async () => {
      try {
        const response = await getAllOffers();
        let result;
        if (typeof response === 'string') {
          result = response;
        } else {
          result = await response.json();
        }

        if (typeof result === 'string') {
          setServerError(result);
        } else if (Array.isArray(result)) {
          setOffersResult(result); // Correctly set the array of offers
        }
      } catch (error) {
        setServerError('Failed to fetch offers');
      }
    };

    fetchOffers();
  }, []); // Empty dependency array ensures this runs once on mount

  // Create an offer
  const onOfferCreate = (e: any) => {
    e.preventDefault();
    const target = e.target as HTMLFormElement;
    const newOffer = (target[0] as HTMLInputElement)?.value;

    if (!newOffer) return;

    if (offersCreated.includes(newOffer)) {
      alert('Offer already exists');
      return;
    }

    setOffersCreated((prev) => [...prev, newOffer]);
  };

  // Delete an offer
  const onOfferDelete = (e: SyntheticEvent) => {
    e.preventDefault();
    const target = e.target as HTMLFormElement;
    const offerToRemove = (target[0] as HTMLInputElement)?.value;

    if (!offerToRemove) return;

    setOffersCreated((prev) =>
      prev.filter((request) => request !== offerToRemove)
    );
  };
  
  return (
    <div>
      {serverError && (
        <p className="text-red-500 text-center mb-4">{serverError}</p>
      )}

      <ListOffers
        offersResult={offersResult}
        onOfferCreate={onOfferCreate}
      />
    </div>
  )
};

export default OffersPage;
