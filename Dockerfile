# Sử dụng hình ảnh cơ sở cho .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Đặt thư mục làm việc trong container
WORKDIR /app

# Sao chép tệp csproj của dự án Data và yourlook vào thư mục làm việc
COPY yourlook/yourlook.csproj yourlook/
COPY Data/Data.csproj Data/

# Khôi phục các gói cho các dự án
RUN dotnet restore yourlook/yourlook.csproj
RUN dotnet restore Data/Data.csproj

# Sao chép toàn bộ mã nguồn vào thư mục làm việc
COPY . ./

# Xây dựng và xuất bản ứng dụng
RUN dotnet publish yourlook/yourlook.csproj -c Release -o out

# Sử dụng hình ảnh cơ sở cho .NET runtime để chạy ứng dụng
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Cổng mà ứng dụng sẽ lắng nghe
EXPOSE 5089

# Chạy ứng dụng
ENTRYPOINT ["dotnet", "yourlook.dll"]

