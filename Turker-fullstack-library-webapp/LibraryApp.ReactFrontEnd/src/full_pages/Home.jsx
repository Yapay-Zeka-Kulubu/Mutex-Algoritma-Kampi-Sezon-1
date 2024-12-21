import BookOperationsCard from '../Components/OperationsCards/BookOperationsCard.jsx';
import MessageOperationsCard from '../Components/OperationsCards/MessageOperationsCard.jsx';
import MemberOperationsCard from '../Components/OperationsCards/MemberOperationsCard.jsx';
import GeneralOperationsCard from '../Components/OperationsCards/GeneralOperationsCard.jsx';
import AuthorOperationsCard from '../Components/OperationsCards/AuthorOperationsCard.jsx';
import { useUser } from '../AccountOperations/UserContext.jsx';
import StaffOfMonthCard from '../Components/StaffOfMonthCard.jsx';
import CardLink from '../Components/CardLink.jsx';

function Home() {
    const { user } = useUser();

    //TODO graphical version of reports page
    
    let mainContent = "";

    if (!user)
        mainContent = (<div className='grow  p-10 self-center text-center text-text'>
            <div>
                <h1 className='text-4xl mb-4'>Welcome to the library</h1>
                <p>Please <b>login or register</b> to our library from the <b>top right corner</b> to be able to do any kind of operations.</p>
            </div>
        </div>);
    else if (user.isPunished)
        mainContent = (<div className='grow  p-10 self-center text-center text-text'>
            <div>
                <h1 className='text-4xl mb-4'>Welcome to the library</h1>
                <p className='mb-4'>You are <b className='text-danger'>punished</b> from library. <b className='text-danger'>Your current fine is: {user.fineAmount}$</b>. Please contact with the staffs for further operations.</p>
                <CardLink url="/ViewInbox" text="View inbox to see details" />
            </div>
        </div>)
    else if (user.roleName === "pendingUser")
        mainContent = (<div className='grow p-10 self-center text-center text-text'>
            <div>
                <h1 className='text-4xl mb-4'>Welcome to the library</h1>
                <p>Please wait for your account <b>approval</b>. Our personnel will check soon.</p>
            </div>
        </div>)
    else if (user)
        mainContent = (
            <div className="grid grid-cols-1 gap-12 p-10 container lg:my-10 xl:my-10 lg:mx-24 xl:mx-24 lg:grid-cols-2 xl:grid-cols-3">
                {(["member", "staff", "manager", "author"].includes(user.roleName)) && (
                    <>
                        <StaffOfMonthCard />
                        <BookOperationsCard />
                        <MessageOperationsCard />
                    </>
                )}
                {
                    (["staff", "manager"].includes(user.roleName)) && (
                        <>
                            <GeneralOperationsCard />
                            <MemberOperationsCard />
                        </>
                    )}
                {
                    (user.roleName === "manager") && (
                        <>
                            <AuthorOperationsCard />
                        </>
                    )}
            </div>
        );

    return mainContent;
}

export default Home;