import './App.css';
import Btn from './BTN/Btn.jsx';
import CollectionCardsYsp from './collection/CollectionCardsYsp.jsx';
import DatePicker from './datePicker/DatePicker.jsx';
import React, { useState } from 'react';

function App() {
    const [selectedDate, setSelectedDate] = useState(new Date());

    return (
        <div className="left-0">
            <div className="relative static text-center content-center box-border z-0 top-0 width-100 h-20 bg-gradient-to-l from-transparent to-slate-500">
                <div class="flex justify-between ...">
                    <div className="p-4">
                        <h2>4gaDWR</h2>
                    </div>
                    <div className="p-4">
                        <h2>4gaBoard Daily Work Review</h2>
                    </div>
                    <div className="p-4">
                        <p>&copy; 2026 INFERYSP</p>
                    </div>
                </div>

             </div>
            <div className="relative z-1 mx-100 left-0">
                <DatePicker date={selectedDate} onDateChange={setSelectedDate} />
                <div className="grid grid-cols-1 gap-6">
                    <CollectionCardsYsp day={selectedDate} />
                </div>
                <Btn cardId="1699997500410169099" />
            </div>
        </div>
    );
    
}

export default App;