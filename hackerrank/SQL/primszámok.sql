declare 
	@prime_list nvarchar(max),
	@range int = 1000,
	@outer_iter int = 2,
	@inner_iter int = 2,
	@is_prime bit = 0

while (@range > @outer_iter)
begin
	set @is_prime = 1
	set @inner_iter = 2
	
	while (@inner_iter < power(@outer_iter,0.5) + 1)
	begin
		if (@outer_iter % @inner_iter = 0) 
		begin
			set @is_prime = 0
			break
		end
		set @inner_iter += 1
	end
	
	if (@is_prime = 1)
	begin
		set @prime_list = concat(@prime_list,@outer_iter,'&')
	end
	set @outer_iter += 1
end
print left(@prime_list, len(@prime_list) - 1)