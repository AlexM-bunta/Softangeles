import {Card} from "primereact/card";
import {Button} from "primereact/button";

export const CardLoan = ({description, title, subtitle, urlImage, onClick}: {
    description: string;
    title: string;
    subtitle?: string;
    urlImage?: string;
    onClick: () => void
}) => {

    const header = (
        <img alt="Card" src={urlImage} height={300} width={220}/>
    );
    const footer = (
        <>
            <Button label="Apply" icon="pi pi-check" onClick={() => onClick()}/>
        </>
    );

    return (
        <>
            <Card
                style={{width: "390px", boxShadow: "rgba(100, 100, 111, 0.2) 0px 7px 29px 0px", marginBottom: "1.4rem"}}
                title={title}
                subTitle={subtitle} footer={footer} header={header}
                className="md:w-25rem">
                <p className="m-0">
                    {description}
                </p>
            </Card>
        </>
    )
}