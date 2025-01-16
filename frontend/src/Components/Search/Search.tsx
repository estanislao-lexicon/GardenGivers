import React, { JSX, SyntheticEvent } from 'react'

interface Props {
    onSearchSubmit: (e: SyntheticEvent) => void;
    search: string | undefined;
    handleSearchChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
}

const Search : React.FC<Props> = ({
  onSearchSubmit, 
  search, 
  handleSearchChange
}: Props) : JSX.Element => { 

  const handleButtonClick = (e: SyntheticEvent) => {
    e.preventDefault(); // Prevent form submission behavior
    onSearchSubmit(e);  // Call the parent onClick function
  };

  return (
    <section className='relative'>
      <div className='max-w-4xl mx-auto p-6 space-y-6'>
        <form 
          className="form relative flex flex-col w-full p-10 space-y-4 rounded-lg md:flex-row md:space-y-0 md:space-x-3"
          onSubmit={onSearchSubmit}
        >
          <input 
            className="flex-1 p-3 border-2 rounded-lg  focus:outline-none"
            value={search} 
            onChange={(e) => handleSearchChange(e)}
          ></input>
          <button className="text-gray-600" onClick={handleButtonClick} >
            Search 
          </button>          
        </form>            
      </div>  
    </section>
  )
}

export default Search;
