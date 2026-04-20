import React, { useEffect, useState, useContext } from 'react';
import CardWorkReview from './CardWorkReview/CardWorkReview.jsx';
import { format } from "date-fns";
import { TimerContext } from '../../TimerContext.jsx';
import { DataContext } from '../../DataContext.jsx';
import CollectionCards from './CollectionCards.jsx';

function CollectionCardsYsp({ day, data }) {
    const { setTimerSum } = useContext(TimerContext);
    const { setCardsNumber } = useContext(DataContext);
    const { setData } = useContext(DataContext);

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
                console.log(`Iloœæ kart CollectionCards ${result.length}`)
                setCardsNumber(result.length);

            } catch (error) {
                setError(error);
            } finally {
                setLoading(false);
            }
        };
        fetchResults();

    }, [day]);


    if (loading) return <p>£adowanie...</p>;

    if (error) return <p>B³¹d: {error.message}</p>;

    return (
        <CollectionCards data={data} />
    );
}

export default CollectionCardsYsp;