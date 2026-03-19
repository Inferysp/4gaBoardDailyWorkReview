import Btn from './components/BTN/Btn.jsx';
import CollectionCardsYsp from './components/collection/CollectionCardsYsp.jsx';
import DatePicker from './components/datePicker/DatePicker.jsx';
import React, { useState } from 'react';

function App() {
    const [selectedDate, setSelectedDate] = useState(new Date());

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
                        <h2>{new Date().toLocaleString()}</h2>
                    </div>
                </div>
            </div>

            <div className="body">
                <div className="bodycolumn">
                    <div className="cardsbar">
                            <DatePicker date={selectedDate} onDateChange={setSelectedDate} />
                            <p>suma timer total w ci¹gu dnia</p>
                    </div>
                <div className="grid grid-cols-1 gap-6">
                    <CollectionCardsYsp day={selectedDate} />
                </div>
                <Btn cardId="1699997500410169099" />
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