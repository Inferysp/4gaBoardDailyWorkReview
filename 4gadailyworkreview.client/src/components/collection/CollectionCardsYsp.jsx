import React, { useEffect, useState, useContext } from 'react';
import CardWorkReview from './CardWorkReview/CardWorkReview.jsx';
import { format } from "date-fns";
import CardBox from './CardBox.jsx';
import { AppContext } from '../../AppContext.jsx';

function CollectionCardsYsp({ day }) {
    const { setTimerSum } = useContext(AppContext);

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

    useEffect(() => {
        if (!data) return;

        const extractTimer = (item) => {
            //if(item.timer != null)
                return JSON.parse(item.timer); // {total, createdAt}
        }

        const increment = (card) => {
            console.log(`card.time ${ card.time }`);
            const timer = extractTimer(card);
            if(timer != null)
                setTimerSum(i => i + timer.total);
        }

        const updateTimerSum = (collection) => {
            for (let card in collection) {
                console.log(`card ${collection[card]}`);
                //if(card.timer != null)
                    increment(collection[card]);
            }
        }

        updateTimerSum(data);

    }, [data]);

    if (loading) return <p>£adowanie...</p>;

    if (error) return <p>B³¹d: {error.message}</p>;

    return (
        <div className="listcontainer">
            <ul>
                {data.map(item => (
                    <li key={item.id}>
                        <CardBox
                            cardName={item.name}
                            description={item.description}
                            timer={item.timer}
                            boardId={item.boardId}
                            listId={item.listId}
                            authorId={item.updatedById}
                            lastChange={item.updatedAt}
                            createDate={item.createdAt}
                        />
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default CollectionCardsYsp;