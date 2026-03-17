import React, { useEffect, useState } from 'react';
import CardWorkReview from './CardWorkReview/CardWorkReview.jsx';
import { format } from "date-fns";
import CardBox from './CardBox.jsx';

function CollectionCardsYsp({ day }) {
    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    const formatedDay = format(day, "yyyy-MM-dd");

    useEffect(() => {
        const fetchResults = async () => {
            try {
                const response = await fetch(`/cards/day/${formatedDay}`);
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }

                const result = await response.json();
                setData(result);
            } catch (error) {
                setError(error);
            } finally {
                setLoading(false);
            }
        };

        fetchResults();
    }, [day]); // Dodano day jako dependency

    if (loading) return <p>£adowanie...</p>;

    if (error) return <p>B³¹d: {error.message}</p>;

    return (
        <div>
            <ul>
                {data.map(item => (
                    <li key={item.id}>
                        <CardWorkReview
                            name={item.name}
                            desc={item.description}
                            creator={item.updatedById}
                        />
                    </li>
                ))}
            </ul>
            <CardBox />
        </div>

    );
}

export default CollectionCardsYsp;