import React, { useState } from 'react'
import ListRequests from '../../Components/Interactions/Request/ListRequests';


interface Props {}

const RequestsPage = (props: Props) => {
  const [requestsCreated, setRequestsCreated] = useState<string[]>([]);

  const onRequestCreate = (e: any) => {
    e.preventDefault();
    const exists = requestsCreated.find((request) => request === e.target[0].value);
    if(exists) {
      return;
    }
    const updatedRequestList = [...requestsCreated, e.target[0].value];
    setRequestsCreated(updatedRequestList);    
  };

  const onRequestDelete = (e: any) => {
    e.preventDefault();
    const removedRequest = requestsCreated.filter((request) => {
      return request !== e.target[0].value;
    });
  };

  return (
    <div>
      <ListRequests requestsCreated={requestsCreated} onRequestDelete={onRequestDelete} />
    </div>
  )
};

export default RequestsPage;
