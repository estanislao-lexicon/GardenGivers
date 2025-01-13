import React, { JSX, SyntheticEvent } from 'react'

interface Props {
    onClick: (e: SyntheticEvent) => void;
    search: string;
    handleChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
}

const Search : React.FC<Props> = ({
  onClick, 
  search, 
  handleChange
}: Props) : JSX.Element => { 

    const handleButtonClick = (e: SyntheticEvent) => {
        e.preventDefault(); // Prevent form submission behavior
        onClick(e);  // Call the parent onClick function
      };

    return (
        <div>
            <input value={search} onChange={(e) => handleChange(e)}></input>
            <button onClick={handleButtonClick} >
                 Search 
            </button>
        </div>  
    )
}

export default Search;
