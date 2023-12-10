import {Chart} from "primereact/chart";
import {randBrand, randColor, randNumber} from "@ngneat/falso";
import {Calendar} from "primereact/calendar";
import {useState} from "react";
import {Nullable} from "primereact/ts-helpers";

const companies = [randBrand(), randBrand(), randBrand()];
const colors = [
    randColor(),
    randColor(),
    randColor()
]

const dataN = [randNumber(), randNumber(), randNumber()]

export const Expenses = ({expenses}: {
    expenses?: number
}) => {
    const [date, setDate] = useState<Nullable<(Date | null)[]>>(null)

    const data = {
        labels: companies,
        datasets: [
            {
                data: dataN,
                backgroundColor: colors

            }
        ]
    }

    const options = {
        plugins: {
            legend: {
                labels: {
                    usePointStyle: true
                }
            }
        }
    };

    return (
        <>

            <span className="p-float-label">
            <Calendar inputId="calendar" value={date} onChange={(e) => setDate(e.value)} selectionMode="range"
                      readOnlyInput/>
                <label htmlFor="calendar">Select period of time:</label>
            </span>

            {date && date[1] && <>
                <span>During {date && date.toLocaleString().split(",").map(date =>
                    <span
                        key={date}>{!date.includes("00:00:00") && date} </span>)}, you had spent {expenses || 3000} RON
                </span>
                <Chart
                    type="pie"
                    data={data}
                    options={options}
                    style={{width: '20rem'}}/>
                <p> Considering your expenses, you could try buying from: </p>
            </>}

        </>
    )
}