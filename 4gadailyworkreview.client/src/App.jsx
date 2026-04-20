import CollectionCardsYsp from './components/collection/CollectionCardsYsp.jsx';
import DatePicker from './components/datePicker/DatePicker.jsx';
import React, { useState, useContext, useEffect, useRef } from 'react';
import { TimerContext } from './TimerContext.jsx';
import { DataContext } from './DataContext.jsx';
import SearchForm from './components/search/SearchForm.jsx';
import CountFilteredCards from './components/count/CountFilteredCards.jsx';
import CollectionCards from './components/collection/CollectionCards.jsx';

function App() {
    const { timerSum, setTimerSum } = useContext(TimerContext);
    const { cardsNumber } = useContext(DataContext);
    const { data } = useContext(DataContext);

    const [selectedDate, setSelectedDate] = useState(new Date());
    const [time, setTime] = useState(new Date().toLocaleString());
    const [searchedData, setSearchedData] = useState(null);

    let timeSumPresentation = "";
    let timerr = timerSum;
    let hours = Math.floor(timerr / 3600);
    let minutes = Math.floor((timerr % 3600) / 60);
    let seconds = timerr % 60;

    let hour = hours < 10 ? `0${hours}:` : `${hours}:`;
    let minute = minutes < 10 ? `0${minutes}:` : `${minutes}:`;
    let second = seconds < 10 ? `0${seconds}` : `${seconds}`;
    timeSumPresentation = `${hour.toString()}${minute.toString()}${second.toString()}`;

    useEffect(() => {
        const timer = setInterval(() => {
            setTime(new Date().toLocaleString());
        }, 1000);

        // Clean up the timer when the component unmounts
        return () => clearInterval(timer);
    }, []);

    useEffect(() => {

        const extractTimer = (item) => {
            return JSON.parse(item.timer);
        }

        const increment = (card) => {
            const timer = extractTimer(card);
            if (timer != null)
                setTimerSum(i => i + timer.total);
        }

        const updateTimerSum = (collection) => {
            setTimerSum(0);
            for (let card in collection) {
                increment(collection[card]);
            }
        }

        if (!data) return;
        updateTimerSum(data);
    }, [data]);

    return (
        <div className="app">
            <div className="menubar">
                <div class="flex justify-between ...">
                    <div className=" text-slate-300 font-bold text-shadow-lg p-4">
                        <h2>4gaDWR</h2>
                    </div>
                    <div className="font-bold text-lg text-gray-800 p-4">
                        <h2>4gaBoard Daily Work Review</h2>
                    </div>
                    <div className=" p-4">
                        <h2>{time}</h2>
                    </div>
                </div>
            </div>

            <div className="body">
                <div className="bodycolumn">
                    <div className="cardsbar">
                        <DatePicker date={selectedDate} onDateChange={setSelectedDate} />
                        <SearchForm setSearchedData={setSearchedData} />
                        <CountFilteredCards number={cardsNumber} />
                        <p>Czas pracy: {timeSumPresentation}</p>
                    </div>
                    <div className="grid grid-cols-1 gap-6">
                        {searchedData === null ?
                            <CollectionCardsYsp day={selectedDate} data={data} />
                            :
                            <CollectionCards data={searchedData} />
                        }
                    </div>
                </div>
            </div>

            <div className="footer">
                <div className="p-4">
                    <p>&copy; 2026 INFERYSP</p>
                </div>
            </div>

        </div>
    );
}

export default App;