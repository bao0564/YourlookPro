# Sử dụng hình ảnh .NET Core SDK để xây dựng ứng dụng
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Thiết lập thư mục làm việc
WORKDIR /app

# Sao chép tệp csproj và khôi phục các gói NuGet
COPY *.csproj ./
RUN dotnet restore

# Sao chép mã nguồn và xây dựng ứng dụng
COPY . ./
RUN dotnet publish -c Release -o out

# Sử dụng hình ảnh .NET Core Runtime để chạy ứng dụng
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Cấu hình ứng dụng để chạy trên cổng 5089
EXPOSE 5089
ENTRYPOINT ["dotnet", "yourlook.dll"]
