import { useState } from "react";
import { addDays, format, parseISO } from "date-fns";

export default function DatePicker({date, onDateChange }) {
    const handlePrev = () => onDateChange( addDays(date, -1) );
    const handleNext = () => onDateChange(addDays(date, 1));
    const handleDateChange = (e) => onDateChange(parseISO(e.target.value));

    return (
        <div className="p-4">
            <button onClick={handlePrev}>←</button>
            <input
                type="date"
                value={format(date, "yyyy-MM-dd")}
                onChange={handleDateChange}
            />
            <button onClick={handleNext}>→</button>
        </div>
    );
}