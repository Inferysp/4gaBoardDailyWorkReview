import React, { useState, useEffect } from 'react';
export default function SearchForm({ setSearchedData }) {
    const [input, setInput] = useState("");
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(false);

    const handleClick = (e) => {
            setInput(e.target.value)
        } 


    useEffect(() => {
        const fetchResults = async () => {
            setSearchedData(null);
            try {
                const response = await fetch(`/cards/filter/${input}`);
                if (!response.ok)
                    throw new error(`HTTP error! Status: ${response.status}`);

                const result = await response.json();

                console.log(`Iloœæ kart searchForm ${result.length}`);
                setSearchedData(result);
            } catch (error) {
                setError(error);
            } finally {
                setLoading(false);
            }


        };
        if (input.length !== 0)
            fetchResults();

    }, [input]);

    if (error != null) return <p>B³¹d: {error.message}</p>;

    if (loading) return <p>£adowanie...</p>;

    return (
        <div className="searchform">
            <input placeholder="Szukaj..." type="text" value={input} onChange={handleClick} />
        </div>
    )
}