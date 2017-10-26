--Stored Procedures

--drops

if object_id ( 'Location', 'P' ) is not null
    drop procedure Location;  
if object_id ( 'UnitCount', 'FN' ) is not null
    drop function CoreCount;  
go

--creates

--Location returns the location id if it exists, otherwise inserts it and returns it.
create procedure Location
@street1 varchar(100) = null,
@street2 varchar(50) = null,
@suburb varchar(50) = null,
@state varchar(50) = null,
@postcode smallint = null,
@campus varchar(50) = null 
as 
begin
	set nocount on;
	select locationid from locations
    where (addressstreet1 = @street1 or
	      (@street1 is null and addressStreet1 is null))
    and   (addressstreet2 = @street2 or
		  (@street2 is null and addressStreet2 is null))
    and   (addressSuburb = @suburb or
		  (@suburb is null and addressSuburb is null))
    and   (addressState = @state or 
		  (@state is null and addressState is null))
    and   (addressPostCode = @postcode or
		  (@postcode is null and addressPostCode is null))
    and   (campus = @campus or
	      (@campus is null and campus is null))
    if @@rowcount = 0 begin
		insert into Locations
		values (@street1, @street2, @suburb, @state, @postcode, @campus);
		select @@identity;
	end
end
go


--Counts the amount of units for a specific unit type.
create function UnitCount(@courseId smallint, @unitType smallint) returns int
as 
begin
	return (
	select count(*) 
	from Course_Units
	join Units on Course_Units.unitId = Units.unitId
	where Units.unitType = @unitType
	);
end