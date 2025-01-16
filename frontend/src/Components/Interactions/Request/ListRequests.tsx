import React, { SyntheticEvent } from 'react'
import CardRequest from './CardRequest';

interface Props {
    requestsCreated: string[];
    onRequestDelete: (e: SyntheticEvent) => void;
}

const ListRequests = ({ requestsCreated, onRequestDelete }: Props) => {
  return (
    <section id="requests-created">
      <h2 className="mb-3 mt-3 text-3xl text-gray-700 font-semibold text-center md:text-4xl">
        Requests Created
      </h2>
      <div className="relative flex flex-col items-center max-w-5xl mx-auto space-y-10 px-10 mb-5 md:px-6 md:space-y-0 md:space-x-7 md:flex-row">
        {requestsCreated && requestsCreated.length > 0 ? (
          requestsCreated.map((requestCreated) => (
            <CardRequest 
              // key={offerCreated.id} 
              requestCreated={requestCreated} 
              onRequestDelete={onRequestDelete}
            />
          ))
        ) : (
          <h2 className="mb-3 mt-3 text-xl text-gray-500 font-semibold text-center md:text-xl">
            No Requests created.
          </h2>
        )}
      </div>      
    </section>
  );
};

export default ListRequests;
